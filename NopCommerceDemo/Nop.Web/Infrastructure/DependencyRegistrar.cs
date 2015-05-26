using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nop.Core.Infrastructure.DependencyManagement;
using Autofac;
using Nop.Core.Infrastructure;
using Nop.Web.Infrastructure.Installation;

namespace Nop.Web.Infrastructure
{
    public class DependencyRegistrar:IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // we cache presentation models between requests

            // installation localization service
            builder.RegisterType<InstallationLocalizationService>().As<IInstallationLocalizationService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}