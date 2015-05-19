﻿using Autofac;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Services.Customers;
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
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            // user agent helper

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

            //pass MemoryCacheManager as cacheManager (cache settings between requests)

            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();


            //pass MemoryCacheManager as cacheManager (cache settings between requests)
            
            // Register event consumers

        }

        public int Order
        {
            get { throw new NotImplementedException(); }
        }
    }
}
