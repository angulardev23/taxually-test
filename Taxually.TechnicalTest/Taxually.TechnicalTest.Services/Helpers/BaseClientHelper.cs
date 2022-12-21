using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Model.Registration;

namespace Taxually.TechnicalTest.Services.Helpers
{
    public abstract class BaseClientHelper
    {
        public readonly VatRegistrationRequest Request;

        public BaseClientHelper(VatRegistrationRequest request) 
        {
            Request = request;
        }

        public abstract Task RegisterVatCountryRequest();
    }
}
