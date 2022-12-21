
using Moq;
using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Factory;
using Taxually.TechnicalTest.Services.Interfaces;
using Taxually.TechnicalTest.Services.Services;

namespace Taxually.TechnicalTest.Services.Tests.Services
{
    public class VatRegistrationServiceTests
    {
        private VatRegistrationService _vatRegistrationService;

        [SetUp]
        public void Setup()
        {
            var clientHelpermock = new Mock<IClientHelper>();
            clientHelpermock
                .Setup(s => s.RegisterVatCountryRequest())
                .Returns(Task.CompletedTask);

            var clientHelperFactoryMonk = new Mock<IClientHelperFactory>();
            clientHelperFactoryMonk
                .Setup(s => s.GetClientHelper(It.IsAny<VatRegistrationRequest>()))
                .Returns(clientHelpermock.Object);

            _vatRegistrationService = new VatRegistrationService(clientHelperFactoryMonk.Object);
        }

        [Test]
        public void RegisterVatRequestTest()
        {
            // arrange
            var request = new VatRegistrationRequest();
            // act
            var result = _vatRegistrationService.RegisterVatRequest(request);
            // assert
            Assert.That(result, Is.Not.Null);
            Assert.DoesNotThrow(delegate { result.Wait(); });
        }
    }
}
