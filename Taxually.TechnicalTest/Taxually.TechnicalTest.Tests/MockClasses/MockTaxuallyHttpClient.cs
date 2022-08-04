using System;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Tests.Models;

public class MockTaxuallyHttpClient : ITaxuallyHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request)
    {
        // Mock logic to simulate work
        var SIMULATED_WORK_DURACTION = TimeSpan.FromSeconds(1);
        return Task.Delay(SIMULATED_WORK_DURACTION);
    }
}