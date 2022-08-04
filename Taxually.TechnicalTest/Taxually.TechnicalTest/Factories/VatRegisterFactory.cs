using Taxually.TechnicalTest.DataClients;
using Taxually.TechnicalTest.Models;
using Taxually.TechnicalTest.VatRegisters;

namespace Taxually.TechnicalTest.Factories;

public class VatRegisterFactory
{
    public IVatRegister GetVatRegister(string countryCode)
    {
        switch (countryCode)
        {
            case "GB":
                return new HttpVatRegister(new TaxuallyHttpClient());
            case "FR":
                return new CsvVatRegister(new TaxuallyQueueClient());
            case "DE":
                return new XmlVatRegister(new TaxuallyQueueClient());

            default:
                throw new Exception("Country not supported");
        }
    }
}