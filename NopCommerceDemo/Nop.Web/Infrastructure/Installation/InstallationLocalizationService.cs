using Nop.Core;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

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
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(filePath);

                    // get language code
                    var languageCode = "";
                    // we file name format: installation.{languagecode}.xml
                    var r = new Regex(Regex.Escape("installation.") + "(.*?)" + Regex.Escape(".xml"));
                    var matches = r.Matches(Path.GetFileName(filePath));
                    foreach (Match match in matches)
                        languageCode = match.Groups[1].Value;

                    // get language friendly name
                    var languageName = xmlDocument.SelectSingleNode(@"//Language").Attributes["Name"].InnerText.Trim();

                    // is default
                    var isDefaultAttribute = xmlDocument.SelectSingleNode(@"//Language").Attributes["IsDefault"];
                    var isDefault = isDefaultAttribute != null ? Convert.ToBoolean(isDefaultAttribute.InnerText.Trim()) : false;

                    // is right to left
                    var isRightToLeftAttribute = xmlDocument.SelectSingleNode(@"//Language").Attributes["IsRightToLeft"];
                    var isRightToLeft = isRightToLeftAttribute != null ? Convert.ToBoolean(isDefaultAttribute.InnerText.Trim()) : false;

                    // create language
                    var language = new InstallationLanguage
                    {
                        Code = languageCode,
                        Name = languageName,
                        IsDefault = isDefault,
                        IsRightToLeft = isRightToLeft,
                    };
                    // load resources
                    foreach (XmlNode resNode in xmlDocument.SelectNodes(@"//Language/LocaleResource"))
                    {
                        var resNameAttribute = resNode.Attributes["Name"];
                        var resValueNode = resNode.SelectSingleNode("Value");

                        if (resNameAttribute == null)
                            throw new NopException("All installation resources must have an attribute name=\"Value\".");
                        var resourceName = resNameAttribute.Value.Trim();
                        if (string.IsNullOrEmpty(resourceName))
                            throw new NopException("All installation resource attributes 'Name' must have a value.");

                        if (resValueNode == null)
                            throw new NopException("All installation resources must have an element \"Value\".");
                        var resourceValue = resValueNode.InnerText.Trim();

                        language.Resources.Add(new InstallationLocalResource
                        {
                            Name = resourceName,
                            Value = resourceValue
                        });
                    }

                    _availableLanguages.Add(language);
                    _availableLanguages = _availableLanguages.OrderBy(l => l.Name).ToList();
                }
            }

            return _availableLanguages;
        }
    }
}