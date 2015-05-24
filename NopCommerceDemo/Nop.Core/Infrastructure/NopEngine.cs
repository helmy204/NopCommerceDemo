using Autofac;
using Autofac.Integration.Mvc;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Core.Infrastructure
{
    // TODO: Not Finished
    /// <summary>
    /// Engine
    /// </summary>
    public class NopEngine : IEngine
    {
        #region Fields

        private ContainerManager _containerManager;

        #endregion Fields

        #region Utilities

        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="config">Config</param>
        protected virtual void RegisterDependencies(NopConfig config)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            // we create new instance of ContainerBuilder
            // because Build() or Update() method can only be called once on a ContainerBuilder.

            // dependencies
            //var typeFinder=new WebAppTypeFinder
            builder = new ContainerBuilder();
            builder.RegisterInstance(config).As<NopConfig>().SingleInstance();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            //-->
            builder.Update(container);

            // register dependencies provided by other assemblies
            builder = new ContainerBuilder();
            //-->
            //-->
            //-->
            //-->
            // sort
            //-->
            //-->
            //-->
            builder.Update(container);

            this._containerManager = new ContainerManager(container);

            // set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
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

            // startup tasks
            //-->
            //-->
            //-->
            //-->
        }

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Container manager
        /// </summary>
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        #endregion Properties

       

       

        

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
