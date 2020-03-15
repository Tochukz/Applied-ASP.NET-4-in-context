using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomWebControls
{
    public partial class UsingCustomControl : System.Web.UI.Page
    {


        protected void HandleCalcPerformed(object sender, SwimCalcEventArgs e)
        {
            ResultsControl1.Distance = e.Distance.ToString("F0");
            ResultsControl1.Calories = e.CalsBurned.ToString("F0");
            ResultsControl1.Pace = e.Pace.ToString("F0");
        }
    }
}