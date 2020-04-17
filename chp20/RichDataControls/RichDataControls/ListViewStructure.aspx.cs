using System;


namespace RichDataControls
{
    public class StringAdapter
    {
        public string Name { get; set; }
    }
    
    public partial class ListViewStructure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public StringAdapter[] DataItems = new[]
        {
            new StringAdapter{Name = "Item 01"},
            new StringAdapter{Name = "Item 02"},
            new StringAdapter{Name = "Item 03"},
            new StringAdapter{Name = "Item 04"},
            new StringAdapter{Name = "Item 05"}
        };
    }
}