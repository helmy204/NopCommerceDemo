using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core
{
    // TODO: Not Finished
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        Customer CurrentCustomer { get; set; }

        /// <summary>
        /// Gets or sets the original customer 
        /// (in case the current one is impersonated)
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }

        /// <summary>
        /// Gets or sets the current vendor (logged-in manager)
        /// </summary>
        Vendor CurrentVendor { get; }

        /// <summary>
        /// Gets or set current user working language
        /// </summary>
        Language WorkingLanguage { get; set; }

        /// <summary>
        /// Gets or sets current user working currency
        /// </summary>
        Currency WorkingCurrency { get; set; }
    }
}
