using System;
using System.Web.UI.HtmlControls;

namespace WorkingWithRoutes.Models
{
    public partial class Customer1 : System.Web.UI.Page
    {
        public Models.Customer Customer = new Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            int customerId;
            try
            {
                if (int.TryParse(RouteData.Values["customerId"].ToString(), out customerId))
                {
                    Customer = Data.Repository.GetCustomers().Find(customer => customer.Id == customerId)?? new Customer();
                }
               
            }
            catch(Exception ex)
            {
                HtmlControl errorDiv = Master.FindControl("errorDiv") as HtmlControl;
                HtmlGenericControl p1 = new HtmlGenericControl("p");
                HtmlGenericControl p2 = new HtmlGenericControl("p");
                p1.InnerText = ex.InnerException?.Message?? ex.Message;
                p2.InnerText = ex.InnerException?.StackTrace?? ex.StackTrace;
                errorDiv.Controls.Add(p1);
                errorDiv.Controls.Add(p2);
               
            }
            
        }

        protected void Page_Error(object o, EventArgs e)
        {
            Response.Write(string.Format("<div class='alert-warining'>No customer with ID of {0} was found in our records</p>", 0));
        }
    }
}