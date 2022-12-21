using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Client;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public class FRClientHelper : BaseClientHelper
    {
        private const string _frenchVatCsvPath = "vat-registration-csv";

        public FRClientHelper(VatRegistrationRequest request) : base(request)
        {
        }

        public override Task RegisterVatCountryRequest()
        {
            // France requires an excel spreadsheet to be uploaded to register for a VAT number
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{Request.CompanyName}{Request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var excelQueueClient = new TaxuallyQueueClient();
            // Queue file to be processed
            return excelQueueClient.PostAsync(_frenchVatCsvPath, csv);
        }
    }
}
