using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Infrastructure
{
    // TODO: Not Finished
    /// <summary>
    /// Engine
    /// </summary>
    public class NopEngine : IEngine
    {

        #region Utilities

        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="config">Config</param>
        protected virtual void RegisterDependencies(NopConfig config)
        {
            // TODO: Here
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// Initialize components and plugins in the nop environment.
        /// </summary>
        /// <param name="config">Config</param>
        public void Initialize(NopConfig config)
        {
            // register dependencies
            RegisterDependencies(config);
        }

        #endregion Methods

        public DependencyManagement.ContainerManager ContainerManager
        {
            get { throw new NotImplementedException(); }
        }

       

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
