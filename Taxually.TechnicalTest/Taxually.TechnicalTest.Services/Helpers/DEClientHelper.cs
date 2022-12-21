using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Client;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public class DEClientHelper : BaseClientHelper
    {
        private const string _germanVatXmlPath = "vat-registration-xml";

        public DEClientHelper(VatRegistrationRequest request) : base(request)
        {
        }

        public override Task RegisterVatCountryRequest()
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
