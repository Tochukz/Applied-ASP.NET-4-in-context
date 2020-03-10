using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WashShopAdminApp.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected string Username;
        protected void Page_Load(object sender, EventArgs e)
        {
            Username = Session["username"] as string;
        }
    }
}