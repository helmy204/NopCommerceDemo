using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Localization
{
    public class LocalizationSettings : ISettings
    {
        //-->>

        //-->>

        /// <summary>
        /// A value indicating whether SEO friendly URLs with multiple languages
        /// are enabled
        /// </summary>
        public bool SeoFriendlyUrlsForLanguageEnabled { get; set; }
    }
}
