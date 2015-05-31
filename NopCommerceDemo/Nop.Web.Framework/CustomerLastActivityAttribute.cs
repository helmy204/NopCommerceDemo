using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Web.Framework
{
    public class CustomerLastActivityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            if (filterContext == null || filterContext.HttpContext == null)
                return;

            // don't apply filter to child method
            if (filterContext.IsChildAction)
                return;

            // only GET requests
            if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var customer = workContext.CurrentCustomer;

            // update last activity date
            if (customer.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
            {
                var customerService = EngineContext.Current.Resolve<ICustomerService>();
                customer.LastActivityDateUtc = DateTime.UtcNow;
                customerService.UpdateCustomer(customer);
            }
        }
    }
}
