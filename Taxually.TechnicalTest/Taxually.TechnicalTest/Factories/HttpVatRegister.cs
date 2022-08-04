using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Factories;

public class HttpVatRegister : IVatRegister
{
    private readonly TaxuallyHttpClient _httpClient;

    public HttpVatRegister()
    {
        _httpClient = new TaxuallyHttpClient();
    }

    public Task Register(VatRegistrationModel model)
    {
        // TODO move URL to appsettings
        return _httpClient.PostAsync("https://api.uktax.gov.uk", model);
    }
}