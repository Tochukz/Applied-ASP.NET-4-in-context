using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandlingErrors
{
    public partial class Default : PageController
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (this.ArgumentOutOfRangeExceptionControl.Checked)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (this.InvalidOperationExceptionControl.Checked)
                {
                    throw new InvalidOperationException();
                }
                else if (this.NotImplementedExceptionControl.Checked)
                {
                    throw new NotImplementedException();
                }
            }
        }

        /*
        protected void Page_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex is ArgumentOutOfRangeException)
            {
                
                // Response.Write("<h3>Error Page: ArgumentOutOfRangeException</h3>");
                // Response.Write("<p>A useful desciption for the user</p>");
                // Response.Write("<a href=\"/Default.aspx\">Click here tp start over</a>");
                
                // Tells ASP.NET server that the exception have been handled and no further action is required.  
                Server.ClearError();
                

                Server.Transfer("/CustomError.aspx");
            }
        }
         */
    }
}