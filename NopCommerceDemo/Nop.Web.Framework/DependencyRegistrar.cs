using Autofac;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Web.Framework
{
    public class DependencyRegistrar:IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // HTTP context and other related stuff

            // web helper



            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();

        }

        public int Order
        {
            get { throw new NotImplementedException(); }
        }
    }
}
