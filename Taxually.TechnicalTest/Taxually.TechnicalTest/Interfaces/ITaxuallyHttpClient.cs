namespace Taxually.TechnicalTest.Interfaces;

public interface ITaxuallyHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request);
}