using System.Text;

namespace CustomWebControls
{
    public partial class UsingUserControl : System.Web.UI.Page
    {

        /* Handle method for the user control event */
        protected void HandleCalcPerformed(object sender, SwimCalcEventArgs e)
        {
            // compose the results 
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Distance: {0:F2} miles\n", e.Distance);
            stringBuilder.AppendFormat("Calories Burend: {0:F0}\n", e.CalsBurned);
            stringBuilder.AppendFormat("Pace: {0:F0} sec/lap\n", e.Pace);

            // set the results text
            TextBox1.Text = stringBuilder.ToString();
        }
    }
}