using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Client
{
    public class TaxuallyQueueClient : ITaxuallyClient
    {
        public Task PostAsync<TPayload>(string queueName, TPayload payload)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
