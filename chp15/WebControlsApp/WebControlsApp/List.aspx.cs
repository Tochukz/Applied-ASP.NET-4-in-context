using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsApp
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] texts = { "Item 1", "Item 2", "Item 3" };
            foreach(string text in texts)
            {
                BulletList2.Items.Add(new ListItem(text));
            }
        }
    }
}