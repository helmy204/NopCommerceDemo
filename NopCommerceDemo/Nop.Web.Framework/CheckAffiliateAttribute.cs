using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Framework
{
    public class CheckAffiliateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null || filterContext.HttpContext == null)
                return;

            HttpRequestBase request = filterContext.HttpContext.Request;
            if (request == null)
                return;

            //don't apply filter to child methods
            if (filterContext.IsChildAction)
                return;

            if(request.QueryString!=null&&request.QueryString["AffiliatedId"]!=null)
            {
                var affiliateId = Convert.ToInt32(request.QueryString["AffiliateId"]);

                if (affiliateId > 0)
                {
                    //var affiliateService=EngineContext.Current.Resolve<IAffiliateService
                }
            }
        }
    }
}
