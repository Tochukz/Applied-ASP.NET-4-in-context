using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsApp
{
    public partial class Link : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1Changed(object sender, EventArgs e)
        {
            result.InnerText = "Event was triggred - text has chaged";
        }
    }
}