using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Common;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace Nop.Web
{
    // TODO: Not Finished
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // register custom routes (plugins, etc)
            //-->>
            //-->>

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Nop.Web.Controllers" }
                );
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Initialize engine context
            EngineContext.Initialize(false);

            bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled();
            if (databaseInstalled)
            {
                // remove all view engines
                ViewEngines.Engines.Clear();
                // except the themeable razor view engine we use
                //ViewEngines.Engines.Add(new ThemeableRazorViewEngine();
            }


            // Add some functionality on top of the default ModelMetaProvider
            //-->>

            // Registering some regular mvc stuff
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            // fluent validation
            //-->>
            //-->>

            // start scheduled tasks
            //-->>
            //-->>
            //-->>
            //-->>

            // log application start
            //-->>
            //-->>
            //-->>
            //-->>
            // log
            //-->>
            //-->>
            //-->>
            //-->>
            //-->>
            // don't throw new exception if occurs
            //-->>
            //-->>
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // ignore static resources
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            //-->>
            //-->>

            // keep alive page requested (we ignore it to prevent creating a guest customer records)
            //-->>
            //-->>
            //-->>

            // ensure database is installed
            if (!DataSettingsHelper.DatabaseIsInstalled())
            {
                string installUrl = string.Format("{0}install", webHelper.GetStoreLocation());
                if (!webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase))
                {
                    this.Response.Redirect(installUrl);
                }
            }

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            // log error
            LogException(exception);

            // TODO: HERE
        }

        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            // ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404 &&
                !EngineContext.Current.Resolve<CommonSettings>().Log404Errors)
                return;

            try
            {
                // log
                var logger = EngineContext.Current.Resolve<ILogger>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                logger.Error(exc.Message, exc, workContext.CurrentCustomer);
            }
            catch (Exception)
            {
                // don't throw new exception if occurs
            }

            // TODO: HERE
        }
    }
}