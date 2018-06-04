using OBTM.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace OnlineBusTicketManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IUnityContainer _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _container = new UnityContainer();
            Configure.RegisterMappings(_container);

        }
    }
}
