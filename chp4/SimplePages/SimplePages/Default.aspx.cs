using System;
using System.Text;
using System.Web.UI;

namespace SimplePages
{
    public partial class Default: Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Setting the content of the ul element with id of numberList 
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 4; i++) 
            {
                builder.AppendFormat("<li>{0}</li>\n", i);
            }
            numberList.InnerHtml = builder.ToString();

            // Setting the content for the div element with id thingsListDiv
            builder.Clear();
            builder.AppendLine("Here are some things I like to do:");
            builder.AppendLine("<ol>");
            string[] things = new string[] { "Swim", "Cycle", "Run" };
            foreach (string str in things)
            {
                builder.AppendFormat("<li>{0}</li>\n", str);
            }
            builder.AppendLine("</ol>");
            thingsListDiv.InnerHtml = builder.ToString();

            // Setting the attributes of the image element with id of image
            image.Src = "Images/triathlon.png";
            image.Alt = "Triathlon Symbol";

            // Setting the href attribute and content of the link with id of secondPageLink
            secondPageLink.HRef = "SecondPage.aspx";
            secondPageLink.InnerText = "Second Page";
        }
    }
}