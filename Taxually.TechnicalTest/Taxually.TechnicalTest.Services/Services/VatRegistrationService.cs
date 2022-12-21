using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Interfaces;
using Taxually.TechnicalTest.Services.Factory;

namespace Taxually.TechnicalTest.Services.Services
{
    public class VatRegistrationService : IVatRegistrationService
    {
        public async Task RegisterVatRequest(VatRegistrationRequest request)
        {
            var registerTask = ClientHelperFactory.GetClientHelperTask(request);
            await registerTask.RegisterVatCountryRequest();
        }
    }
}
