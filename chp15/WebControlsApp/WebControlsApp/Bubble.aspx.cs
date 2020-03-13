using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsApp
{
    public partial class Bubble : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            /* When implementing the OnBubbleEvent method, we return true if we have handled the event and it should 
             * not be bubbled any further; otherwise, we return false. 
             */
            if (args is CommandEventArgs)
            {
                CommandEventArgs ce = (CommandEventArgs)args;

                Label1.Text = String.Format("<b>Command Name:</b> {0}, <b>Command Argument:</b> {1}", ce.CommandName, ce.CommandArgument);
                return true;
            }
            return false;
        }
    }
}