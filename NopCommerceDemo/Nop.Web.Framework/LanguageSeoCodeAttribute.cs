using Nop.Core.Data;
using Nop.Core.Domain.Localization;
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
    /// <summary>
    /// Attribute which ensures that store URL contains a language SEO code
    /// if "SEO friendly URLs with multible languages" setting is enabled
    /// </summary>
    public class LanguageSeoCodeAttribute : ActionFilterAttribute
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

            //only GET requests
            if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            var localizationSettings = EngineContext.Current.Resolve<LocalizationSettings>();
            if (!localizationSettings.SeoFriendlyUrlsForLanguageEnabled)
                return;

            //// ensures that this route is registered and localizable (LocalizedRoute in RouteProvider.cs)
            //if (filterContext.RouteData == null || filterContext.RouteData.Route == null || !(filterContext.RouteData.Route is LocalizeRoute))
            //    return;
        }
    }
}
