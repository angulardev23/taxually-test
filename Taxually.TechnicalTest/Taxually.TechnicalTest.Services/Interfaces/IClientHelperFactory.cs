using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Helpers;

namespace Taxually.TechnicalTest.Services.Interfaces
{
    public interface IClientHelperFactory
    {
        public IClientHelper GetClientHelper(VatRegistrationRequest request);
    }
}
