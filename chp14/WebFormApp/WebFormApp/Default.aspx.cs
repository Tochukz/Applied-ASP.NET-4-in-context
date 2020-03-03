using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WebFormApp.Calculations;

namespace WebFormApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "1";
                TextBox2.Text = "20";
                TextBox3.Text = "60";
                TextBox4.Text = "1070";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int laps, length, mins, cals;
            if (int.TryParse(TextBox1.Text, out laps) && 
                int.TryParse(TextBox2.Text, out length) &&
                int.TryParse(TextBox3.Text, out mins) &&
                int.TryParse(TextBox4.Text, out cals))
            {
                SwimCalcResult calcResult = SwimCalc.PerformCalculation(laps, length, mins, cals);

                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Distance: {0:F2} miles\n", calcResult.Distance);
                builder.AppendFormat("Calories Burned: {0:F0}\n", calcResult.Calories);
                builder.AppendFormat("Pace: {0:F0} sec/lap\n", calcResult.Pace);

                TextBox5.Text = builder.ToString();
            }
        }
    }
}