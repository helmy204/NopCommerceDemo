using Nop.Core;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Nop.Web.Infrastructure.Installation
{
    /// <summary>
    /// Localization service for installation process
    /// </summary>
    public partial class InstallationLocalizationService : IInstallationLocalizationService
    {
        //-->>

        /// <summary>
        /// Available languages
        /// </summary>
        private IList<InstallationLanguage> _availableLanguages;

        public string GetResource(string resourceName)
        {
            throw new NotImplementedException();
        }

        public InstallationLanguage GetCurrentLanguage()
        {
            throw new NotImplementedException();
        }

        public void SaveCurrentLanguage(string languageCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of available languages
        /// </summary>
        /// <returns>Available installation languages</returns>
        public virtual IList<InstallationLanguage> GetAvailableLanguages()
        {
            if (_availableLanguages == null)
            {
                _availableLanguages = new List<InstallationLanguage>();
                var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                foreach (var filePath in Directory.EnumerateFiles(webHelper.MapPath("~/App_Data/Localization/Installation/"), "*.xml"))
                {

                }
            }

            throw new NotImplementedException();
        }
    }
}