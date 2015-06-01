using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Security
{
    public class SecuritySettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether all pages will be forced
        /// to use SSL (no matter of a specified [NopHttpsRequirementAttribute]
        /// attribute)
        /// </summary>
        public bool ForceSslForAllPages { get; set; }

        //-->>

        //-->>
    }
}
