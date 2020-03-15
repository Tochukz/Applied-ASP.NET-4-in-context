using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomWebControls.Calculator;
using System.ComponentModel;

namespace CustomWebControls
{
    /**
     * This is a user control that renders a form with four input fields. 
     * It features the EnableTextBoxAutoPostBack property/attribute which can be use to set AutoPostBack on all in input fields. 
     */
    public class SwimCalcEventArgs : EventArgs
    {
        private SwimCalcResult result;

        public float Distance { get { return result.Distance; } }

        public float CalsBurned { get { return result.Calories; } }

        public float Pace { get { return result.Pace; } }

        public SwimCalcEventArgs(SwimCalcResult res)
        {
            result = res;
        }
    }

    public partial class SwimCalc : System.Web.UI.UserControl
    {
        public event EventHandler<SwimCalcEventArgs> CalcPerformed;

        /* Adding a property to the user control */
        [DefaultValue(false)]
        [Category("Behavior")]
        public bool EnableTextBoxAutoPostBack { get; set; }

        private float[] lastInputs;

        protected void Page_Load(object sender, EventArgs e)
        {
            // configure the TextBoxes based on the property value
            foreach(TextBox textBox in new [] { LapsText, LengthText, MinText, CalsText})
            {
                textBox.AutoPostBack = EnableTextBoxAutoPostBack;
            }

            int laps, length, mins, cals;

            if (int.TryParse(LapsText.Text, out laps) &&
                int.TryParse(LengthText.Text, out length) &&
                int.TryParse(MinText.Text, out mins) && 
                int.TryParse(CalsText.Text, out cals))
            {
                float[] newinputs = new float[] { laps, length, mins, cals };
                // perform the calculations only if one of the inputs has changed
                if (lastInputs == null || !lastInputs.SequenceEqual(newinputs))
                {
                    SwimCalcResult result = SwimCalculator.PerformCalculation(laps, length, mins, cals);

                    // invoke the event
                    OnCalcPerformed(new SwimCalcEventArgs(result));
                    lastInputs = newinputs;
                }
            }
        }

        protected virtual void OnCalcPerformed(SwimCalcEventArgs args)
        {
            EventHandler<SwimCalcEventArgs> handler = CalcPerformed;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /* Imlementign a control state */
        protected override void OnInit(EventArgs e)
        {   /* This is done to store input values between request in other to recalculation if an input value changes.
            *  This is called control state.
            *  We could use the session or view state instead but they can be disabled on a per-page basis which makes them unreliable .
            *  The control state cannot be disabled and is a more reliable way of storing data essential for the operation of a control.           
            */
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        /* To load the control state we require. It is called at the start of the control's life cycle. */
        protected override void LoadControlState(object saveState)
        {
            if (saveState != null)
            {
                lastInputs = (float[])saveState;
            }
        }

        /* To store the control state we made we simple return the data. This should be a small data */
        protected override object SaveControlState()
        {
            return lastInputs;
        }
    }
}