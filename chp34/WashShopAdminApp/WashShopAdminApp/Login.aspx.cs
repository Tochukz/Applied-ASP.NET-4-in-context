using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WashShopAdminApp.DAL;
using System.Web.Security;

namespace WashShopAdminApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginClick(object sender, EventArgs e)
        {
  
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();
            if (DBHelper.IsValidUser(username, password))
            {
                Session["username"] = username;
                Session["role"] = DBHelper.GetUserRoles(username);

                FormsAuthentication.SetAuthCookie(username, false);

                string returnUrl = Request.QueryString["ReturnUrl"] as string;
                Response.Redirect(returnUrl?? "/Admin");
            }
            else
            {
                ErrorMsg.Text = "Login Failed";
            }
        }
    }
}