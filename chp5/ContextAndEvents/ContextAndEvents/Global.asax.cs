using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ContextAndEvents
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Inserts string into the response sent to the browser. Appears before the HTML element.
            Response.Write(string.Format("<p>Request processing started at: {0}</p>", GetTimeString()));
        }

       protected void Application_EndRequest(object sender, EventArgs e)
       {
            // Inserts string into the response sent to the browser. Appears after the HTML element.
            Response.Write(string.Format("<p>Request processing ended at: {0} </p>", GetTimeString()));
       }

       private string GetTimeString()
        {
            return DateTime.Now.ToString("hh:mm:ss:ff");
        }
    }
}