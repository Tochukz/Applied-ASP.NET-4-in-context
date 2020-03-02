using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace WorkingWithRoutes
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generating a route by using the route name
            additionLink.HRef = RouteTable.Routes.GetVirtualPath(null, "addition-page", null).VirtualPath;

            // Generating a route using with parameter
            thirdCustomer.HRef = RouteTable.Routes.GetVirtualPath(null, "customer-page", new RouteValueDictionary() { { "customerId", 3 } }).VirtualPath;
        }
    }
}