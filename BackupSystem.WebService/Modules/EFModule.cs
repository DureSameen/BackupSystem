using Autofac;
using BackupSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackupSystem.WebService.Modules
{
    public class EFModule: Autofac.Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(BackupSystemContext)).As(typeof(IContext)).InstancePerLifetimeScope();
        }
    }
}