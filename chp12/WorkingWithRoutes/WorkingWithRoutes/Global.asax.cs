using System;
using System.Web.Routing;

namespace WorkingWithRoutes
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            Data.Repository.InitData();
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            /* Disable direct access to .aspx files. First you have to Enable routing when request are for files on disk for this to work */
            routes.RouteExistingFiles = true;
            routes.MapPageRoute("asp-pages", "{page}.aspx/{*otherVars}", "~/NonExistingPage.aspx");

            routes.MapPageRoute("home-page", "", "~/Default.aspx");
            routes.MapPageRoute("customers-page", "Customers", "~/CustomerList.aspx");
            routes.MapPageRoute("customer-page", "Customers/{customerId}", "~/Customer.aspx");

            /* Route with variable */
            //routes.MapPageRoute("items-page", "Items/{type}", "~/ItemTypes.aspx", true, new RouteValueDictionary() { { "type", "all" } });
            
            /* Route with constraint on the variable segment  and default value */
            routes.MapPageRoute("items-page", "Items/{type}", "~/ItemTypes.aspx", true, new RouteValueDictionary() { { "type", "all"} }, new RouteValueDictionary() { { "type", "all|short|shirt|jacket" } });

            /* Variable lenth variable segment */
            routes.MapPageRoute("addition-page", "Add/{*numbers}", "~/Addition.aspx", true);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}