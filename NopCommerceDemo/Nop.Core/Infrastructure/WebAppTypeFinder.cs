using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Provides information about types in the current web application.
    /// Optionally this class can look at all assemblies in the bin folder.
    /// </summary>
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region Fields

        private bool _ensureBinFolderAssembliesLoaded = true;

        #endregion Fields

        #region Ctor

        public WebAppTypeFinder(NopConfig config)
        {
            this._ensureBinFolderAssembliesLoaded = config.DynamicDiscovery;
        }

        #endregion Ctor
    }
}
