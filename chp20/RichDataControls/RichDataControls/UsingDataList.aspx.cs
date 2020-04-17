using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RichDataControls
{
    public partial class UsingDataList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item index using the DataList.SelectedIndex property
            // The DataList.SelectedIndex Property will return -1 when no item is selcted.
            DataList1.DataBind();
        }
    }
}