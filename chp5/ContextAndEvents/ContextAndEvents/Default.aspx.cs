using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContextAndEvents
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            placeHolder3.InnerHtml = "The message was changed from in the Page_Load method";
            WriteContextValue("Path", Request.Path);
            WriteContextValue("HttpMethod", Request.HttpMethod);

            switch(Request.Browser.Browser)
            {
                case "Chrome":
                    browserInfo.InnerText = string.Format("Request was made using Chrome Browser version {0}", Request.Browser.Version);
                    break;
                case "IE":
                    browserInfo.InnerText = string.Format("Request was made using Internet explorer version {0}", Request.Browser.Version);
                    break;
                default:
                    browserInfo.InnerText = string.Format("Request was made using other bowser: {0}", Request.Browser.Browser);
                    break;
            }
            //Response.Redirect("FinalPage.html", true); // "true" will make execution of the page terminated.   
            //Server.Transfer("FinalPage.html", true); // Unlike REsponse.Redirect() this method does not redirect the browser but only transfers execution to the second page.

            //Server.Transfer("SecondPage.aspx?messageToDisplay=first", true);

            /* Instead of accessing HttpRequest, HttpResponse and other context object via properties of Page, you can also access them using the HttpContext class */
            //HttpContext context = HttpContext.Current;
            //context.Server.Transfer("SecondPage.aspx?messageToDisplay=first", true);  

            /* You can use the Items collection of the Context object to pass infomation between pages */
            Context.Items.Add("messageToDisplay", 1);
            Server.Transfer("ThirdPage.aspx");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            placeHolder3.InnerHtml = "This changed in the PagePreRender method";
            //This h4 element will the displayed before the HTML element in the webpage
            Response.Write("<h4>This message comes from the PagePreEnder method.<h4>");
        }

        private void WriteContextValue(string nameParam, string valParam)
        {
            contextDiv.InnerHtml += string.Format("<b>{0}</b> {1}</p>", nameParam, valParam);
        }
    }
}

/**
 * Request is a property of the System.Web.UI.Page class. It holds a reference to an object of type System.Web.HttpRequest
 * The Request.Browser property returns a System.Web.HttpBrowserCapability object. From this object you ca read of the Browser property or the Version property.
 * The Response property of the System.Web.UI.Page class holds a reference to the System.Web.HttpRespone object.
 * The Server property of the Page class returns a System.Web.HttpServerUtitlity object. 
 * 
 * There is a subtle difference between Response.Redirect() and Server.Transfer() methods
 * - Response.Redirect() takes the user's browser to the page of the url passed as the first argument.
 * - Server.Transfer() keeps the user in the original page but returns the response of the url passed as the first argument.
 * 
 * Instead of using the Page class, you can also access context object by using the static Current property of the HttpContext class 
 * HttpContext context = HttpContext.Current
 * From context object you can get the Request object context.Request, server object context.Server
 * 
 * You must not store and reuse the HttpContext object. A new one is created for each page request and trying to an old one will cause an exception.  
 * 
 * Note that when you are working in a class derives from Page, you can access the HttpContext object using the Context property. This is equivalent to calling the static Current property of HttpContext class.
 * 
 * The Items property of the Context class can be used to pass name/value pairs around during the processing of a page.  
 * 
 */
  