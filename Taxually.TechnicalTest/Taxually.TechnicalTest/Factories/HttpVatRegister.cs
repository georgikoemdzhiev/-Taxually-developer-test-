using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Factories;

public class HttpVatRegister : IVatRegister
{
    private readonly ITaxuallyHttpClient _httpClient;

    public HttpVatRegister(ITaxuallyHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task Register(IVatRegistrationModel model)
    {
        // TODO move URL to appsettings
        return _httpClient.PostAsync("https://api.uktax.gov.uk", model);
    }
}