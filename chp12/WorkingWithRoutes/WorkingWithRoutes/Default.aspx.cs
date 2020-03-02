using System;
using System.Web.Routing;


namespace WorkingWithRoutes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Redirect to a routed URL*/
            //Response.RedirectToRoute("customers-page");

            /* Redirect to a routed URL with parameter*/
            Response.RedirectToRoute("items-page", new RouteValueDictionary { { "type", "jacket" } });
        }
    }
}