using Application;
using Autofac;
using Autofac.Integration.WebApi;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Pizzeria_WebAplication.App_Start
{
    public class AutofacWebApiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            

            builder.RegisterType<PizzaContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<PizzaContext>()
                   .As<IPizzaContext>()
                   .InstancePerRequest();

            builder.RegisterType<PizzaService>()
                   .As<IPizzaService>()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(DbSet<>))
                   .As(typeof(IDbSet<>))
                   .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}