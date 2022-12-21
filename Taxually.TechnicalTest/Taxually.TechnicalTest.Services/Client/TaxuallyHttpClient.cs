using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Client
{
    public class TaxuallyHttpClient : ITaxuallyClient
    {
        public Task PostAsync<TRequest>(string url, TRequest request)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
