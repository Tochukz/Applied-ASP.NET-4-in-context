using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkingWithRoutes
{
    public partial class ItemTypes : System.Web.UI.Page
    {
        public List<Models.ItemType> ItemList; 

        protected void Page_Load(object sender, EventArgs e)
        {
            string type = RouteData.Values["type"]?.ToString();
            if ( type == "all")
            {
                ItemList = Data.Repository.GetItemTypes();
                
            }
            else
            {
                ItemList = Data.Repository.GetItemTypes().FindAll(item => item.Type.ToLower() == type.ToLower());
            }
        }
    }
}