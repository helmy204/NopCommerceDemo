using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Infrastructure
{
    // TODO: Not Finished
    /// <summary>
    /// Provides access to the singlton instance of the Nop engine.
    /// </summary>
    public class EngineContext
    {
        #region Utilities

        protected static IEngine CreateEngineInstance(NopConfig config)
        {
            if (config != null && !string.IsNullOrEmpty(config.EngineType))
            {
                var engineType = Type.GetType(config.EngineType);
                if (engineType == null)
                    throw new ConfigurationErrorsException("The type '" + config.EngineType + "' could not be found. Please check the configuration at /configuration/nop/engine[@engineType] or check for missing assemblies.");
                if (!typeof(IEngine).IsAssignableFrom(engineType))
                    throw new ConfigurationErrorsException("The type '" + engineType + "' doesn't implement 'Nop.Core.Infrastructure.IEngine' and cannot be configured in /configuration/nop/engine[@engineType] for that purpose.");
                return Activator.CreateInstance(engineType) as IEngine;
            }

            return new NopEngine();
        }

        #endregion Utilities

        #region Methods

        // really is the same as using lock(this) on the whole method
        /// <summary>
        /// Initialize a static instance of the Nop factory.
        /// </summary>
        /// <param name="forceRecreate">Creates a new factory instance even though the factory has been previously initialized.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                var config = ConfigurationManager.GetSection("NopConfig") as NopConfig;
                Singleton<IEngine>.Instance = CreateEngineInstance(config);
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the singleton Nop engine used to access Nop services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if(Singleton<IEngine>.Instance==null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }

        #endregion Properties

    }
}
