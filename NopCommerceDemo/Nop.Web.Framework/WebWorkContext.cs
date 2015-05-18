using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nop.Web.Framework
{
    // TODO: Not Finished
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Fields

        private readonly HttpContextBase _httpContext;

        private Customer _cachedCustomer;

        #endregion Fields

        #region Properties

        public Customer CurrentCustomer
        {
            get
            {
                if (_cachedCustomer != null)
                    return _cachedCustomer;

                Customer customer = null;
                if(_httpContext==null||_httpContext is FakeHttpContext)
                {
                    // check whether request is made by a background task
                    // in this case return built-in customer record for background task
                    //customer=
                }



                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion Properties

        public Core.Domain.Customers.Customer OriginalCustomerIfImpersonated
        {
            get { throw new NotImplementedException(); }
        }


        public Core.Domain.Vendors.Vendor CurrentVendor
        {
            get { throw new NotImplementedException(); }
        }

        public Core.Domain.Localization.Language WorkingLanguage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Core.Domain.Directory.Currency WorkingCurrency
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Core.Domain.Tax.TaxDisplayType TaxDisplayType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAdmin
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
