using Taxually.TechnicalTest.Model.Registration;

namespace Taxually.TechnicalTest.Services.Interfaces
{
    public interface IVatRegistrationService
    {
        Task RegisterVatRequest(VatRegistrationRequest request);
    }
}
