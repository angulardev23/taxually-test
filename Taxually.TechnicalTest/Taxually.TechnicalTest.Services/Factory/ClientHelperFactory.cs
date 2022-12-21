using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Helpers;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Factory
{
    public class ClientHelperFactory : IClientHelperFactory
    {
        public IClientHelper GetClientHelper(VatRegistrationRequest request)
        {
            IClientHelper helper = request.Country switch
            {
                "GB" => new GBClientHelper(request),
                "FR" => new FRClientHelper(request),
                "DE" => new DEClientHelper(request),
                _ => throw new ArgumentException("Country not supported")
            };

            return helper;
        }
    }
}
