using NUnit.Framework;
using Taxually.TechnicalTest.Factories;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Tests.Models;

namespace Taxually.TechnicalTest.Tests;

public class TaxuallyHttpClient
{
    private ITaxuallyHttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new MockTaxuallyHttpClient();
    }

    [Test]
    public void Can_Initiate_Post_Request()
    {
        // Arrange
        var URL = "https://MOCK.URL.COM";
        var requestBody = "mock";

        // Act
        var result = _httpClient.PostAsync<string>(URL, requestBody);

        // Assert
        Assert.NotNull(result);
    }
}