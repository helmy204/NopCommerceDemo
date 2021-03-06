﻿using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Fakes;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Helpers;
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
        #region Const

        private const string CustomerCookieName = "Nop.customer";

        #endregion Const

        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly ICustomerService _customerService;


        private readonly IAuthenticationService _authenticationService;

        private readonly IUserAgentHelper _userAgentHelper;

        private Customer _cachedCustomer;
        private Customer _originalCustomerIfImpersonated;

        #endregion Fields

        #region Ctor

        #endregion Ctor

        #region Utilities

        protected virtual HttpCookie GetCustomerCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[CustomerCookieName];
        }

        #endregion Utilities

        #region Properties

        public Customer CurrentCustomer
        {
            get
            {
                if (_cachedCustomer != null)
                    return _cachedCustomer;

                Customer customer = null;
                if (_httpContext == null || _httpContext is FakeHttpContext)
                {
                    // check whether request is made by a background task
                    // in this case return built-in customer record for background task
                    customer = _customerService.GetCustomerBySystemName(SystemCustomerNames.BackgroundTask);
                }

                // check whether request is made by a search engine
                // in this case return built-in customer record for search engines
                // or comment the following two lines of code in order to
                // disable this functionality
                if (customer == null || customer.Deleted || !customer.Active)
                {
                    if (_userAgentHelper.IsSearchEngine())
                        customer = _customerService.GetCustomerBySystemName(SystemCustomerNames.SearchEngine);
                }

                // registered user
                if(customer==null||customer.Deleted||!customer.Active)
                {
                    customer = _authenticationService.GetAuthenticatedCustomer();
                }

                // imporsonate user if required (currently user for 'phone order' support)
                if(customer!=null&&!customer.Deleted&&customer.Active)
                {
                    var impersonatedCustomerId = customer.GetAttribute<int?>(SystemCustomerAttributeNames.ImpersonatedCustomerId);
                    if (impersonatedCustomerId.HasValue && impersonatedCustomerId.Value > 0)
                    {
                        var impersonatedCustomer = _customerService.GetCustomerById(impersonatedCustomerId.Value);
                        if(impersonatedCustomer!=null&&!impersonatedCustomer.Deleted&&impersonatedCustomer.Active)
                        {
                            // set impersonated customer
                            _originalCustomerIfImpersonated = customer;
                            customer = impersonatedCustomer;
                        }
                    }
                }

                // load guest customer
                if (customer == null || customer.Deleted || !customer.Active)
                {
                    var customerCookie = GetCustomerCookie();
                    if(customerCookie!=null&&!String.IsNullOrEmpty(customerCookie.Value))
                    {
                        Guid customerGuid;
                        if (Guid.TryParse(customerCookie.Value, out customerGuid))
                        {
                            var customerByCookie = _customerService.GetCustomerByGuid(customerGuid);
                            if (customerByCookie != null &&
                                // this customer (from cookie) should not be registered
                                !customerByCookie.IsRegistered())
                                customer = customerByCookie;
                        }
                    }
                }

                // create guest if not exists
                if(customer==null||customer.Deleted||!customer.Active)
                {
                    customer = _customerService.InsertGuestCustomer();
                }

                // validation
                if(!customer.Deleted&&customer.Active)
                {
                    //SetCus
                }

                return _cachedCustomer;
            }
            set
            {
                //Set
                _cachedCustomer = value;
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
