using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControlsApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button myDivButton = new Button();
            myDivButton.Text = "Press Me!";
            myDivButton.Click += new EventHandler(myDivButton_Click);

            myDiv.Controls.Add(myDivButton);
            /* setting style for HtmlControl*/
            myDiv.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "Bisque");

            Button myPanelButton = new Button();
            myPanelButton.Text = "Press Me!";
            myPanelButton.Click += new EventHandler(myPanelButton_Click);

            myPanel.Controls.Add(myPanelButton);
            /* Setting style for webcontrol*/
            myPanel.BackColor = Color.Bisque;

            /* Using the PlaceHolder control */
            Button button = new Button();
            button.Text = DateTime.Now.ToString(); ;
            PlaceHolder1.Controls.Add(button);
        }

        void myPanelButton_Click(object sender, EventArgs e)
        {
            results.InnerText = "The panel button was pressed";
        }

        void myDivButton_Click(object sender, EventArgs e)
        {
            results.InnerText = "The div button was pressed";
        }
    }
}