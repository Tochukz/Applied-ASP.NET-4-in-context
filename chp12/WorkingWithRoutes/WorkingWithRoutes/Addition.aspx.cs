using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WorkingWithRoutes
{
    public partial class Addition : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string numberString = RouteData.Values["numbers"]?.ToString();            
            if (numberString != null)
            {
                string[] numbers = numberString.Split('/');
                double total = 0; ;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < numbers.Length; i++)
                {
                    total += double.Parse(numbers[i]);
                    builder.Append(string.Format("<span>{0}</span>", numbers[i]));
                    if(i != numbers.Length-1)
                    {
                        builder.Append("+");
                    }
                }
                builder.Append(string.Format("<span>={0}<span>", total));
                result.InnerHtml = builder.ToString();
            }
        }
    }
}