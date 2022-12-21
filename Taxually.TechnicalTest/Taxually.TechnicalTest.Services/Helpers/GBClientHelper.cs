using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Client;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public class GBClientHelper : BaseClientHelper
    {
        private const string _ukApi = "https://api.uktax.gov.uk";

        public GBClientHelper(VatRegistrationRequest request) : base(request)
        {
        }

        public override Task RegisterVatCountryRequest()
        {
            // UK has an API to register for a VAT number
            var httpClient = new TaxuallyHttpClient();
            return httpClient.PostAsync(_ukApi, Request);
        }
    }
}
