using System.Xml.Serialization;
using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Client;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public class DEClientHelper : IClientHelper
    {
        private const string _germanVatXmlPath = "vat-registration-xml";
        private readonly VatRegistrationRequest _request;

        public DEClientHelper(VatRegistrationRequest request)
        {
            _request = request;
        }

        public Task RegisterVatCountryRequest()
        {
            // Germany requires an XML document to be uploaded to register for a VAT number
            using var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringwriter, this);
            var xml = stringwriter.ToString();
            var xmlQueueClient = new TaxuallyQueueClient();
            // Queue xml doc to be processed
            return xmlQueueClient.PostAsync(_germanVatXmlPath, xml);
        }
    }
}
