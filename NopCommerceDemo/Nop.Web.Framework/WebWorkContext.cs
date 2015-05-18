using Nop.Core;
using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Web.Framework
{
    // TODO: Not Finished
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Fields

        //private readonly HttpContextBase

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
