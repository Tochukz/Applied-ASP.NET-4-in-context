using System;
using System.Text;
using SwimCalculator.Calculations;

namespace SwimCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            } 
            else
            {
                int laps, length, mins, cals;

                if (int.TryParse(lapsInput.Value, out laps) && 
                    int.TryParse(lengthInput.Value, out length) && 
                    int.TryParse(minsInput.Value, out mins) && 
                    int.TryParse(calsInput.Value, out cals))
                {
                    try
                    {
                        SwimCalcResult calcResult = SwimCalc.PerformCalculation(laps, length, mins, cals);
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("<b>Result</b>");
                        stringBuilder.AppendFormat("<p>Distance: {0:F2} miles</p>", calcResult.Distance);
                        stringBuilder.AppendFormat("<p>Calories Burned: {0:F0}</p>", calcResult.Calories);
                        stringBuilder.AppendFormat("<p>Pace : {0:F0} sec/lap</p>", calcResult.Pace);

                        // set the results text
                        results.InnerHtml = stringBuilder.ToString();

                        // clear the stringBuilder so we can reuse it  
                        stringBuilder.Clear();
                        stringBuilder.Append("<b>Previous results</b>");

                        // get the previous results if they are in the view data
                        /*
                        if (ViewState["lastResults"] != null)
                        {
                            float[] oldDataArray = (float[])ViewState["lastResults"];
                            stringBuilder.AppendFormat("<p>Distance: {0:F2} miles<p>", oldDataArray[0]);
                            stringBuilder.AppendFormat("<p>Calories Burned: {0:F0}", oldDataArray[1]);
                            stringBuilder.AppendFormat("<p>Pace: {0:F0} sec/lap</p>", oldDataArray[2]);
                        } else
                        {
                            stringBuilder.Append("<p>No previous results are available<p>");
                        }
                        // set the view state data
                        ViewState["lastResults"] = new float[] { calcResult.Distance, calcResult.Calories, calcResult.Pace };
                        */

                        // get the previous result of they are in the session state
                        if (Session["lastResults"] != null)
                        {
                            SwimCalcResult oldData = (SwimCalcResult)Session["lastResults"];
                            stringBuilder.AppendFormat("<p>Distance: {0:F2} miles<p>", oldData.Distance);
                            stringBuilder.AppendFormat("<p>Calories Burned: {0:F0}", oldData.Calories);
                            stringBuilder.AppendFormat("<p>Pace: {0:F0} sec/lap</p>", oldData.Pace);

                        }
                        else
                        {
                            stringBuilder.Append("<p>No previou results are available</p>");
                        }
                        Session["lastResults"] = calcResult;

                        //You may also use Application state in place of Session state like this if (Application["lastResult"] != null) {...} ...
                        oldResults.InnerHtml = stringBuilder.ToString();
                    } 
                    catch (ArgumentOutOfRangeException)
                    {
                        results.InnerText = "Error: parameter out of range";
                    }
                }
                else
                {
                    results.InnerText = "Error: could not process input values";
                }
            }
            // Settng default values
            lapsInput.Value = "1";
            lengthInput.Value = "20";
            minsInput.Value = "60";
            calsInput.Value = "1070";
        }
    }
}

/*
 * ASP.NET automatically sets the content of the input elements based on the values submitted with the form.  
 * 
 * You can assign a custom type value to a Session key without the need of applying the [serializable] attribute the the type.
 * If you want to assign a custom type value to a ViewState key you must apply the [serializable attribute to the custom type's definition.
 * 
 */
 
 /* 
ASP.NET takes responsibility for associating the correct session data for the page request that your
code-behind class has been instantiated to service. You don’t need to use session state keys that include
the session identifier, for example. In Listing 6-8, different users can be performing swimming
calculations simultaneously, and ASP.NET will ensure that the data associated with the lastResults key
is the correct data for that user.
 */
