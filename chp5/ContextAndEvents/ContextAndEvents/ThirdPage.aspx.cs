using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContextAndEvents
{
    public partial class ThirdPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            /* The Items collection returns the stored values as object instance, so we need to cast them to the desired type, in this case, we cast to an int value.  */
            int messageToDisplay = Context.Items.Contains("messageToDisplay") ? (int)Context.Items["messageToDisplay"] : 0;
            if (messageToDisplay == 1)
            {
                para.InnerText = "This is the first message";
            } else if (messageToDisplay == 2)
            {
                para.InnerText = "This is the second message";
            } else
            {
                para.InnerText = string.Format("The message is: {0}, {1}", messageToDisplay, Context.Items.Contains("MessageToDisplay"));
            }
        }
    }
}