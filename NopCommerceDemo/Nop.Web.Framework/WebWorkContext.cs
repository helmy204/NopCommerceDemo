using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Web.Framework
{
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        public Core.Domain.Customers.Customer CurrentCustomer
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

        public Core.Domain.Customers.Customer OriginalCustomerIfImpersonated
        {
            get { throw new NotImplementedException(); }
        }
    }
}
