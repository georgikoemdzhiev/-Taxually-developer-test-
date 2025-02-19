﻿using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Factories;
using Taxually.TechnicalTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly VatRegisterFactory _vatRegisterFactory;
        private readonly string[] _supportedCountryCodes;

        public VatRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
            _supportedCountryCodes = _configuration.GetValue<string>("SupportedCountryCodes").Split(',');

            // TODO use Dependency Injection here
            _vatRegisterFactory = new VatRegisterFactory();
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationModel model)
        {
            // the client must send country code
            if (model.Country == null || !_supportedCountryCodes.Contains(model.Country)) return new BadRequestResult();

            var vatRegister = _vatRegisterFactory.GetVatRegister(model.Country);
            try
            {
                await vatRegister.Register(model);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new StatusCodeResult(500);
            }
        }
    }
}