

namespace Taxually.TechnicalTest.Services.Interfaces
{
    public interface ITaxuallyClient
    {
        Task PostAsync<TRequest>(string resource, TRequest request);
    }
}
