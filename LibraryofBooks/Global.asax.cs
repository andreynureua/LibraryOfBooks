using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LibraryofBooks.ViewModels;
using System.Data.Entity;
using Ninject.Modules;
using LibraryofBooks.Util;
using LibraryofBooks.BLL.Infrastructure;
using Ninject;
using Ninject.Web.Mvc;
using LibraryofBooks.DAL;
using System.Web.Http;

namespace LibraryofBooks
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<LibraryContext>(new StoreDbInitializer());


            //NinjectModule bookModule = new BookModule();
            //NinjectModule serviceModule = new ServiceModule("DbConnect");
            //var kernel = new StandardKernel(bookModule, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
