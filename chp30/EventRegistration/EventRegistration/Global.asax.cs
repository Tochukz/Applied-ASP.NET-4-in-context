using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EventRegistration.Infrastructure;

namespace EventRegistration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyResolver.SetResolver(new CustomDependencyResolver());

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterRoutes(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            /* Ignore request for web resource file */
            routes.IgnoreRoute("{resource}.axd/*{pathInfo}");
            
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] {"EventRegistration.Controllers"}
            );
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            /* Display the 'FormatError' view to when Exceptions of type FormatException goes unhandled */
            filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(FormatException), View = "FormatError" });

            filters.Add(new HandleErrorAttribute() { View = "CustomError"});
        }
    }
}
