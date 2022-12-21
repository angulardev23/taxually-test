using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Factory;
using Taxually.TechnicalTest.Services.Helpers;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Tests.Factory
{
    [TestFixture]
    public class ClientHelperFactoryTests
    {
        private IClientHelperFactory _clientHelperFactory;

        [SetUp]
        public void Setup()
        {
            _clientHelperFactory = new ClientHelperFactory();
        }

        [Test]
        public void GetClientHelperTest()
        {
            // arrange
            var frRequest = new VatRegistrationRequest { Country = "FR" };
            var gbRequest = new VatRegistrationRequest { Country = "GB" };
            var deRequest = new VatRegistrationRequest { Country = "DE" };
            // act
            var frHelper = _clientHelperFactory.GetClientHelper(frRequest);
            var gbHelper = _clientHelperFactory.GetClientHelper(gbRequest);
            var deHelper = _clientHelperFactory.GetClientHelper(deRequest);
            // assert
            Assert.That(frHelper, Is.Not.Null);
            Assert.That(frHelper is FRClientHelper);
            Assert.That(gbHelper, Is.Not.Null);
            Assert.That(gbHelper is GBClientHelper);
            Assert.That(deHelper, Is.Not.Null);
            Assert.That(deHelper is DEClientHelper);
        }

        [Test]
        public void GetClientHelperCountryNotSupportedTest()
        {
            // arrange
            //Assert.Throws<ArgumentException>(ClientHelperFactory.GetClientHelper);
            var countryNotSupportedRequest = new VatRegistrationRequest { Country = "Not suppported country" };
            // act/assert
            Assert.Throws<ArgumentException>(delegate { _clientHelperFactory.GetClientHelper(countryNotSupportedRequest); });
        }
    }
}
