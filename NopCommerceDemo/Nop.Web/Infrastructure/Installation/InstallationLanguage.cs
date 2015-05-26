using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Infrastructure.Installation
{
    /// <summary>
    /// Language class for installation process
    /// </summary>
    public partial class InstallationLanguage
    {
        public InstallationLanguage()
        {
            Resources = new List<InstallationLocalResource>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDefault { get; set; }
        public bool IsRightToLeft { get; set; }

        public List<InstallationLocalResource> Resources { get; protected set; }
    }

    public partial class InstallationLocalResource
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}