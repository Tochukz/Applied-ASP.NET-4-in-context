using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContextAndEvents
{
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string messageToDisplay = Request.QueryString["messageToDisplay"];
            if (messageToDisplay != null)
            {
                if (messageToDisplay == "first")
                {
                    placeHolderH4.InnerText = "This is the first message";
                } else {
                    placeHolderH4.InnerText = "This could be any other message";
                }
            } 
            else
            {
                placeHolderH4.InnerText = "No message instruction specified";
            }
        }
    }
}