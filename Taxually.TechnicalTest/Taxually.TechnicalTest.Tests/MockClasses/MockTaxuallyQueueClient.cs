using System;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Tests.Models;

public class MockTaxuallyQueueClient : ITaxuallyQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload)
    {
        // Mock logic to simulate work
        var SIMULATED_WORK_DURACTION = TimeSpan.FromSeconds(1);
        return Task.Delay(SIMULATED_WORK_DURACTION);
    }
}