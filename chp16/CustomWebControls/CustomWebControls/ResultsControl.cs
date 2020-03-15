using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;

namespace CustomWebControls
{
    /**
     * This is a custom server control that is used to display results.
     */
     [ToolboxData("<{0}:ResultsControl runat=server></{0}:ResultsControl>")]
    public class ResultsControl : WebControl
    {
        [Category("Appearance")]
        [DefaultValue("0")]
        public string Distance { get; set; }

        [Category("Appearance")]
        [DefaultValue("0")]
        public string Calories { get; set; }

        [Category("Apperance")]
        [DefaultValue("0")]
        public string Pace { get; set; }

        [Browsable(false)] // This property will not appear in the properties window for the custom control
        public override Color BackColor { set; get; } 

        [Browsable(false)] 
        public override Color ForeColor { set; get; }

        protected override void RenderContents(HtmlTextWriter output)
        {
           if (!string.IsNullOrEmpty(CssClass))
            {  /* We inheric the CssClass property form the the WebControl base class*/
                output.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
            }
            output.RenderBeginTag("div");

            output.RenderBeginTag("div");
            output.Write(string.Format("Distance: {0}", Distance));
            output.RenderEndTag();

            output.RenderBeginTag("div");
            output.Write(string.Format("Calories: {0}", Calories));
            output.RenderEndTag();

            output.RenderBeginTag("div");
            output.Write(string.Format("Pace: {0}", Pace));
            output.RenderEndTag();

            output.RenderEndTag();
        }
    }
}
