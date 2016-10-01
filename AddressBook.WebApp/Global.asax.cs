using AddressBook.Business.Configuration.Autofac;
using AddressBook.Data.Configuration.Autofac;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AddressBook.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Autofac Configuration
            var builder = new ContainerBuilder();

            // Adding registrations 
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ManagerModule());

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            var container = builder.Build();

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}
