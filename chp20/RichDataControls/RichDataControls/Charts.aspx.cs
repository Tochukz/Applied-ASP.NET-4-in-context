using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RichDataControls
{
    public class EventWrapper
    {
        public DateTime Date { set; get; }

        public double Hours { set; get; }

        public float Distance { set; get; }
    }

    public partial class Charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<EventWrapper> Results = new TrainingDataEntities().Events
                            .Select(e => new
                            {
                                Date = e.Date,
                                Time = e.OverallTime,
                                Distance = e.EventType.SwimMiles + e.EventType.CycleMiles + e.EventType.RunMiles
                            })
                            .ToArray()
                            .Select(e => new EventWrapper()
                            {
                                Date = e.Date,
                                Hours = e.Time.TotalHours,
                                Distance = e.Distance
                            });
            
    }


}