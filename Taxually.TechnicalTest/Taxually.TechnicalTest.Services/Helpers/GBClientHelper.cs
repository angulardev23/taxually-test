using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Client;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public class GBClientHelper : IClientHelper
    {
        private const string _ukApi = "https://api.uktax.gov.uk";
        private readonly VatRegistrationRequest _request;

        public GBClientHelper(VatRegistrationRequest request)
        {
            _request = request;
        }

        public Task RegisterVatCountryRequest()
        {
            // UK has an API to register for a VAT number
            var httpClient = new TaxuallyHttpClient();
            return httpClient.PostAsync(_ukApi, _request);
        }
    }
}
