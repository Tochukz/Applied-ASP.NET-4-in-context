using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validation.Calculator;
using System.Text;

namespace Validation
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
                SwimCalcResult calcResult = SwimCalculator.PerformCalculation(laps, length, mins, cals);

                // compose the resuls
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("Distance: {0:F2} miles\n", calcResult.Distance);
                stringBuilder.AppendFormat("Calories Burned: {0:F0}\n", calcResult.Calories);
                stringBuilder.AppendFormat("Pace: {0:F0} sec/lap \n", calcResult.Pace);

                // set the results text
                TextBox5.Text = stringBuilder.ToString();
            }
            else
            {
                TextBox5.Text = "";
            }
        }

        protected void CustomValidator1_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            int convertedValue;
            args.IsValid = int.TryParse(args.Value, out convertedValue) && convertedValue < 50;
        }
    }
}