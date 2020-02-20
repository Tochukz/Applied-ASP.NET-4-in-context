using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace TraceDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Trace.Write("---Started");

            //Trace.Write("Initializing local variable");
            float total = 0;
            if (Session["runningTotal"] != null)
            {
                //Trace.Write("Session state data obtained");
                total = (float)Session["runningTotal"];
            } 
            else if (IsPostBack)
            {
                //Trace.Warn("No session data found");
            }
            else
            {
                //Trace.Write("No session data for initial request");
            }

            if (IsPostBack && Session["runningTotal"] ==  null)
            {
                Debugger.Break();
            }

            if (IsPostBack)
            {
                string data = numericValue.Value;
                //Trace.Write(string.Format("User has entered data: {0}", data));
                if (data != null)
                {
                    float incrementalValue = 0;
                    if (float.TryParse(data, out incrementalValue))
                    {
                        total += incrementalValue;
                       // Trace.Write(string.Format("Numeric value: {0}, new total: {1}", incrementalValue, total));
                    }
                    else
                    {
                        //Trace.Warn("Cannot parse data to float value");
                    }
                }
                else
                {
                    //Trace.Warn("No data has been provided by user");
                }
               
            }
            //Trace.Write("setting displace for total");
            runningTotal.InnerText = string.Format("{0:F2}", total);

            //Trace.Write("Setting new state data value");
            /* The key for this session daat is an intentional typo used the demonstrate soft failure debuging */
            Session["runningTotals"] = total;
            //Trace.Write("---Finished");
        }
    }
}