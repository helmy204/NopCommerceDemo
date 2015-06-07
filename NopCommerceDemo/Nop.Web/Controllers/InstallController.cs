using Nop.Core.Data;
using Nop.Web.Infrastructure.Installation;
using Nop.Web.Models.Install;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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




            return View(model);
        }

        #endregion Methods
    }
}