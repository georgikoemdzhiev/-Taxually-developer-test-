namespace Taxually.TechnicalTest.Interfaces;

public interface ITaxuallyQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload);
}