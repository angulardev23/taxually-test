using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Services
{
    public class VatRegistrationService : IVatRegistrationService
    {
        private readonly IClientHelperFactory _clientHelperFactory;

        public VatRegistrationService(IClientHelperFactory clientHelperFactory) 
        {
            _clientHelperFactory = clientHelperFactory;
        }

        public async Task RegisterVatRequest(VatRegistrationRequest request)
        {
            var registerTask = _clientHelperFactory.GetClientHelper(request);
            await registerTask.RegisterVatCountryRequest();
        }
    }
}
