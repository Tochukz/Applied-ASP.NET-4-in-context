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

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            /* Ignore request for web resource file */
            routes.IgnoreRoute("{resource}.axd/*{pathInfo}");
            
            /** Generic route with a default controller of Home and default action method of Index */
            /* 
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional}
            );*/

            /** contrains the route to either Home or Registration  controller*/
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = "Home|Registration" },
                new string[] {"EventRegistration.Controllers"}
            );

            /* This will map url such as Registration/Index to the Index action method of the Registration class*/
            //routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
