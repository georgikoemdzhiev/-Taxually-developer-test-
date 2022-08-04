using Taxually.TechnicalTest.Factories;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.VatRegisters;

public class HttpVatRegister : IVatRegister
{
    private readonly ITaxuallyHttpClient _httpClient;

    public HttpVatRegister(ITaxuallyHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task Register(VatRegistrationModel model)
    {
        // TODO move URL to appsettings
        return _httpClient.PostAsync("https://api.uktax.gov.uk", model);
    }
}