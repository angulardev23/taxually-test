using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Helpers;

namespace Taxually.TechnicalTest.Services.Factory
{
    public static class ClientHelperFactory
    {
        public static BaseClientHelper GetClientHelper(VatRegistrationRequest request)
        {
            BaseClientHelper helper = request.Country switch
            {
                "GB" => new GBClientHelper(request),
                "FR" => new FRClientHelper(request),
                "DE" => new FRClientHelper(request),
                _ => throw new Exception("Country not supported")
            };

            return helper;
        }
    }
}
