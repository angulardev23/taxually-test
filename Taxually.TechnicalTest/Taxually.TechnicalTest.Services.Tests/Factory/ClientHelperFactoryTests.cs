using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Factory;
using Taxually.TechnicalTest.Services.Helpers;

namespace Taxually.TechnicalTest.Services.Tests.Factory
{
    [TestFixture]
    public class ClientHelperFactoryTests
    {
        [Test]
        public void GetClientHelperTest()
        {
            // arrange
            var frRequest = new VatRegistrationRequest { Country = "FR" };
            var gbRequest = new VatRegistrationRequest { Country = "GB" };
            var deRequest = new VatRegistrationRequest { Country = "DE" };
            // act
            var frHelper = ClientHelperFactory.GetClientHelper(frRequest);
            var gbHelper = ClientHelperFactory.GetClientHelper(gbRequest);
            var deHelper = ClientHelperFactory.GetClientHelper(deRequest);
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
            Assert.Throws<ArgumentException>(delegate { ClientHelperFactory.GetClientHelper(countryNotSupportedRequest); });
        }
    }
}
