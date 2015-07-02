using Autofac;
using BackupSystem.WebService.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackupSystem.WebService.Host
{
    public static class AutofacContainerBuilder
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        /// <returns></returns>
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register types
            builder.RegisterType<BackupManager>();
            builder.RegisterType<LoggerService>();
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            
            // build container
            return builder.Build();
        }
    }
}