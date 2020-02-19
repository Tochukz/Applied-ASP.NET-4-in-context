using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandlingErrors
{
    public partial class CustomError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            // We need to unpack HttpUnhandledException instance so that we get inner exception to work with
            if (ex is HttpUnhandledException)
            {
                ex = ((HttpUnhandledException)ex).InnerException;
            }

            if (ex != null)
            {
                exceptionType.InnerHtml = string.Format("<h3>Error page: {0} </h3>", ex.GetType().ToString());
                message.InnerHtml = "<p>A useful description for the user</p>";

                // Tells ASP.NET server that the exception have been handled and no further action is required.  
                Server.ClearError();
            }
            else
            {
                Server.Transfer("/Default.aspx");
            }
        }
    }
}