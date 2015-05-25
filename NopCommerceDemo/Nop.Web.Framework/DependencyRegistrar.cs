using Autofac;
using Nop.Core;
using Nop.Core.Fakes;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Services.Authentication;
using Nop.Services.Customers;
using Nop.Services.Helpers;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nop.Web.Framework
{
    public class DependencyRegistrar:IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // HTTP context and other related stuff
            builder.Register(c =>
                // register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            // web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            // user agent helper
            builder.RegisterType<UserAgentHelper>().As<IUserAgentHelper>().InstancePerLifetimeScope();

            // controllers

            // data layer

            // plugins

            // cache manager

            // work context
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
            // store context

            // services

            // pass MemoryCacheManager as cacheManager (cache settings between requests)

            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();

            // pass MemoryCacheManager as cacheManager (cache settings between requests)

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();


            //pass MemoryCacheManager as cacheManager (cache settings between requests)
            
            // Register event consumers

        }

        public int Order
        {
            get { return 0; }
        }
    }
}
