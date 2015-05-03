using Autofac;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
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
            


            //builder.RegisterType<DefaultLogger

        }

        public int Order
        {
            get { throw new NotImplementedException(); }
        }
    }
}
