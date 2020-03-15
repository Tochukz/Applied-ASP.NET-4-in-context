using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;

namespace CustomWebControls
{
    /**
     * This is a control adapter that renders a RadioButtonList web control with each radio button element in a div
     * instead of thhe  default table layout that places each radion button in a td element.
     */
    public class RadioButtonListAdaptor: WebControlAdapter
    {
        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "solid"); // You may specify the CSS property as a string e.g "BorderStyle"
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderColor, "black");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "thin");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "150px");
            /* The critical statements: The Name and ID must be set to be able to post request back to the server */
            writer.AddAttribute(HtmlTextWriterAttribute.Id, Control.ID); // You masy specify the attribute name as a string e.g "Id"
            writer.AddAttribute(HtmlTextWriterAttribute.Name, Control.ID);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            /* We can get details about the control we are adapting throuth the Control proprty of the WebControlAdapter base class */
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            RadioButtonList radioButtonList = Control as RadioButtonList;
            if (radioButtonList != null)
            {
                int counter = 0;
                foreach(ListItem item in radioButtonList.Items)
                {
                    // open the div element
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    // set the attributes for the input element
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, Control.ID + "_" + counter);
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, Control.ID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, item.Value);
                   
                    if (item.Selected)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
                    }

                    // write the input element
                    writer.RenderBeginTag(HtmlTextWriterTag.Input);
                    writer.RenderEndTag();

                    // write the lable element
                    writer.RenderBeginTag(HtmlTextWriterTag.Label);
                    writer.Write(item.Text);
                    writer.RenderEndTag();

                    // close the div element
                    writer.RenderEndTag();
                    
                    /* Register all the possible values that might be posted back to the server */
                    /* If you don't do this the the ASP.NET framework will assume that the user 
                     * is trying to forge a request and will report an error.
                     */
                    Page.ClientScript.RegisterForEventValidation(Control.ID, item.Value);
                    /* Adds the value of the ListItem being processed to the set of expected results  */

                    counter++;
                }
            }
        }
    }
}