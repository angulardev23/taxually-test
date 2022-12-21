using System.Text;
using Taxually.TechnicalTest.Model.Registration;
using Taxually.TechnicalTest.Services.Client;
using Taxually.TechnicalTest.Services.Interfaces;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public class FRClientHelper : IClientHelper
    {
        private const string _frenchVatCsvPath = "vat-registration-csv";
        private readonly VatRegistrationRequest _request;

        public FRClientHelper(VatRegistrationRequest request)
        {
            _request = request;
        }

        public Task RegisterVatCountryRequest()
        {
            // France requires an excel spreadsheet to be uploaded to register for a VAT number
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{_request.CompanyName}{_request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            var excelQueueClient = new TaxuallyQueueClient();
            // Queue file to be processed
            return excelQueueClient.PostAsync(_frenchVatCsvPath, csv);
        }
    }
}
