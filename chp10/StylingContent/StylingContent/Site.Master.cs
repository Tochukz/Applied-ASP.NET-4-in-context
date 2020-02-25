using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StylingContent
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (TrainingDataEntities context = new TrainingDataEntities())
            {
                DataTotals totals = DataAccess.GetDataTotals(context);

                eventCountSpan.InnerText = totals.EventTotal.ToString();
                mileCountSpan.InnerText = string.Format("{0:F1}", totals.MileTotal);
                hourCountSpan.InnerText = string.Format("{0} Hours and {1} Minutes", totals.TimeTotal.Hours, totals.TimeTotal.Minutes);
            }
        }
    }
}