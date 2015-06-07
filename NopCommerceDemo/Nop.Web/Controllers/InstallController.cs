using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Security;
using Nop.Web.Infrastructure.Installation;
using Nop.Web.Models.Install;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Controllers
{
    public partial class InstallController : BasePublicController
    {
        #region Fields

        private readonly IInstallationLocalizationService _locService;

        #endregion Fields

        #region Ctor

        public InstallController(IInstallationLocalizationService locService)
        {
            this._locService = locService;
        }

        #endregion Ctor

        #region Utilities

        #endregion Utilities


        #region Methods

        public ActionResult Index()
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
                return RedirectToRoute("HomePage");

            // set page timeout to 5 minutes
            this.Server.ScriptTimeout = 300;

            var model = new InstallModel
            {
                AdminEmail = "admin@yourStore.com",
                InstallSampleData = false,
                DatabaseConnectionString = "",
                DataProvider = "sqlserver",
                // fast installation service does not support SQL compact
                DisableSqlCompact = !String.IsNullOrEmpty(ConfigurationManager.AppSettings["UseFastInstallationService"]) &&
                    Convert.ToBoolean(ConfigurationManager.AppSettings["UseFastInstallationService"]),
                DisableSampleDataOption = !String.IsNullOrEmpty(ConfigurationManager.AppSettings["DisableSampleDataDuringInstallation"]) &&
                    Convert.ToBoolean(ConfigurationManager.AppSettings["DisableSampleDataDuringInstallation"]),
                SqlAuthenticationType = "sqlauthentication",
                SqlConnectionInfo = "sqlconnectioninfo_values",
                SqlServerCreateDatabase = false,
                UseCustomCollation = false,
                Collation = "SQL_Latin1_General_CP1_CI_AS",
            };
            foreach (var lang in _locService.GetAvailableLanguages())
            {
                model.AvailableLanguages.Add(new SelectListItem
                {
                    Value = Url.Action("ChangeLanguage", "Install", new { language = lang.Code }),
                    Text = lang.Name,
                    Selected = _locService.GetCurrentLanguage().Code == lang.Code,
                });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(InstallModel model)
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
                return RedirectToRoute("HomePage");

            // set page timeout to 5 minutes
            this.Server.ScriptTimeout = 300;

            if (model.DatabaseConnectionString != null)
                model.DatabaseConnectionString = model.DatabaseConnectionString.Trim();

            // prepare language list
            foreach (var lang in _locService.GetAvailableLanguages())
            {
                model.AvailableLanguages.Add(new SelectListItem
                {
                    Value = Url.Action("ChangeLanguage", "Install", new { language = lang.Code }),
                    Text = lang.Name,
                    Selected = _locService.GetCurrentLanguage().Code == lang.Code,
                });
            }
            model.DisableSqlCompact = !String.IsNullOrEmpty(ConfigurationManager.AppSettings["UseFastInstallationService"]) &&
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseFastInstallationService"]);
            model.DisableSampleDataOption = !String.IsNullOrEmpty(ConfigurationManager.AppSettings["DisableSampleDataDuringInstallation"]) &&
                Convert.ToBoolean(ConfigurationManager.AppSettings["DisableSampleDataDuringInstallation"]);

            // SQL Server
            if (model.DataProvider.Equals("sqlserver", StringComparison.InvariantCultureIgnoreCase))
            {
                if (model.SqlConnectionInfo.Equals("sqlconnectioninfo_raw", StringComparison.InvariantCultureIgnoreCase))
                {
                    // raw connection string
                    if (string.IsNullOrEmpty(model.DatabaseConnectionString))
                        ModelState.AddModelError("", _locService.GetResource("ConnectionStringRequired"));

                    try
                    {
                        // try to create connection string
                        new SqlConnectionStringBuilder(model.DatabaseConnectionString);
                    }
                    catch
                    {
                        ModelState.AddModelError("", _locService.GetResource("ConnectionStringWrongFormat"));
                    }
                }
                else
                {
                    // values
                    if (string.IsNullOrEmpty(model.SqlServerName))
                        ModelState.AddModelError("", _locService.GetResource("SqlServerNameRequired"));
                    if (string.IsNullOrEmpty(model.SqlDatabaseName))
                        ModelState.AddModelError("", _locService.GetResource("DatabaseNameRequired"));

                    // authentication type
                    if (model.SqlAuthenticationType.Equals("sqlauthentication", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // SQL authentication
                        if (string.IsNullOrEmpty(model.SqlServerUsername))
                            ModelState.AddModelError("", _locService.GetResource("SqlServerUsernameRequired"));
                        if (string.IsNullOrEmpty(model.SqlServerPassword))
                            ModelState.AddModelError("", _locService.GetResource("SqlServerPasswordRequired"));
                    }
                }
            }

            // Consider granting access rights to the resource to the ASP.NET request identity.
            // ASP.NET has a base process identity
            // (typically {MACHINE}\ASPNET on IIS 5 or Network Service on IIS 6 and IIS 7,
            // and the configured application pool identity on IIS 7.5) that is used if the application is not impersonating.
            // If the application is impersonating via <identity impersonate="true"/>
            // the identity will be the anonymous user (typically IUSR_MACHINENAME) or the authenticated request user.
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            // validate permissions
            var dirsToCheck = FilePermissionHelper.GetDirectoriesWrite(webHelper);
            foreach (string dir in dirsToCheck)
                if (!FilePermissionHelper.CheckPermissions(dir, false, true, true, false))
                    ModelState.AddModelError("", string.Format(_locService.GetResource("ConfigureDirectoryPermissions"), WindowsIdentity.GetCurrent().Name, dir));







            return View(model);
        }

        #endregion Methods
    }
}