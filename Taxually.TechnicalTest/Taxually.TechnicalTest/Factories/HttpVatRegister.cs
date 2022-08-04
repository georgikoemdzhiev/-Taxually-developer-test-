using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Factories;

public class HttpVatRegister : IVatRegister
{
    private readonly TaxuallyHttpClient _httpClient;

    public HttpVatRegister()
    {
        // TODO we can use constructor Dependency Injection and inject the queue client
        _httpClient = new TaxuallyHttpClient();
    }

    public Task Register(IVatRegistrationModel model)
    {
        // TODO move URL to appsettings
        return _httpClient.PostAsync("https://api.uktax.gov.uk", model);
    }
}