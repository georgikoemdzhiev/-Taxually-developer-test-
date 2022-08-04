using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Factories;

public class VatRegisterFactory
{
    public IVatRegister GetVatRegister(string countryCode)
    {
        switch (countryCode)
        {
            case "GB":
                return new HttpVatRegister();
            case "FR":
                return new CsvVatRegister();
            case "DE":
                return new XmlVatRegister();

            default:
                throw new Exception("Country not supported");
        }
    }
}