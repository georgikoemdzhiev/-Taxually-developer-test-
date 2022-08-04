using System.Threading.Tasks;
using NUnit.Framework;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Tests.Models;

namespace Taxually.TechnicalTest.Tests;

public class TaxuallyQueueClient
{
    [Test]
    public void Can_Create_Queue()
    {
        // Arrange
        var _queueClient = new MockTaxuallyQueueClient();

        // Act

        // Assert
        Assert.NotNull(_queueClient);
    }

    [Test]
    public void Can_Enqueue_Payload()
    {
        // Arrange
        var queueClient = new MockTaxuallyQueueClient();
        var queueName = "Mock-queue";
        var payload = "mock-payload";

        // Act
        var result = queueClient.EnqueueAsync<string>(queueName, payload);
        // Assert
        Assert.NotNull(result);
    }
}