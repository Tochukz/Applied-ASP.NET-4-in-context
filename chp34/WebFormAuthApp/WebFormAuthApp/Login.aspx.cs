using System;
using System.Web.Security;

namespace WebFormAuthApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string user = Request["username"];
                string pass = Request["password"];
                /* FormsAuthentication.Authenticate() is obsolete. Use Membership.ValidateUser() instead */
                if (FormsAuthentication.Authenticate(user, pass))
                {
                    FormsAuthentication.SetAuthCookie(user, false);
                    Response.Redirect(Request["ReturnUrl"] ?? "~/DEfault.aspx");
                }
            }
        }
    }
}