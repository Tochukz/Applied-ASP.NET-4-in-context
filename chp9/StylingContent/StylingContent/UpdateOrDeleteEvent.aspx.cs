using System;
using System.Linq;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace StylingContent
{
    public partial class UpdateOrDeleteEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (TrainingDataEntities context = new TrainingDataEntities())
            {
                if (ViewState["setupComplete"] == null)
                {
                    PerformPageSetup(context);
                    ViewState["setupComplete"] = true;
                }

                if (!IsPostBack)
                {
                    string mode;
                    int eventID;
                    Event targetEvent;
                    if (
                         (mode = Request.QueryString["mode"]) != null &&
                         int.TryParse(Request.QueryString["id"], out eventID) &&
                         (targetEvent = DataAccess.GetEventByID(context, eventID)) != null
                       )
                    {
                        // set the hidden fields in the form
                        this.modeInput.Value = mode;
                        this.keyInput.Value = eventID.ToString();

                        // use the property values of the event to populate page controls
                        monthSelect.SelectedIndex = targetEvent.Date.Month - 1;
                        dayInput.Value = targetEvent.Date.Day.ToString();
                        yearInput.Value = targetEvent.Date.Year.ToString();

                        // set the selected index for the athlete and event controls
                        SetSelectedIndex(athleteSelect, targetEvent.Athlete);
                        SetSelectedIndex(eventTypeSelect, targetEvent.Type);

                        // set the times
                        swimTimeInput.Value = targetEvent.SwimTime.ToString();
                        cycleTimeInput.Value = targetEvent.CycleTime.ToString();
                        runTimeInput.Value = targetEvent.RunTime.ToString();

                        if (mode == "delete")
                        {
                            monthSelect.Disabled = true;
                            dayInput.Disabled = true;
                            yearInput.Disabled = true;
                            athleteSelect.Disabled = true;
                            eventTypeSelect.Disabled = true;
                            swimTimeInput.Disabled = true;
                            cycleTimeInput.Disabled = true;
                            runTimeInput.Disabled = true;

                            foreach (string controlID in new string[] { "titleDiv", "footerDiv" })
                            {
                                HtmlControl ctrl = Master.FindControl(controlID) as HtmlControl;
                                if (ctrl != null)
                                {
                                    ctrl.Style["background"] = "#980000";
                                }
                            }
                        }

                        button.Value = mode == "edit" ? "Save" : "Delete";

                    }
                    else
                    {
                        Response.Redirect("/ListEvent.aspx");
                    }
                }
                else
                {
                    if (modeInput.Value == "edit")
                    {
                        DataAccess.UpdateEvent(
                            context, int.Parse(keyInput.Value),
                            new DateTime(int.Parse(yearInput.Value), monthSelect.SelectedIndex + 1, int.Parse(dayInput.Value)),
                            athleteSelect.Value,
                            eventTypeSelect.Value,
                            TimeSpan.Parse(swimTimeInput.Value),
                            TimeSpan.Parse(cycleTimeInput.Value),
                            TimeSpan.Parse(runTimeInput.Value)
                        );
                    }
                    else
                    {
                        DataAccess.DeleteEventByID(context, int.Parse(keyInput.Value));
                    }

                    Response.Redirect("/EventList.aspx");
                }
            }
        }

        private void SetSelectedIndex(HtmlSelect selectParam, string targetValue)
        {
            for (int i = 0; i < selectParam.Items.Count; i++)
            {
                if (selectParam.Items[i].Text == targetValue)
                {
                    selectParam.SelectedIndex = i;
                    break;
                }
            }
        }

        private void PerformPageSetup(TrainingDataEntities context)
        {
            // get the current culture info
            DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;


            // populate the month select element
            monthSelect.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                monthSelect.Items.Add(formatInfo.GetAbbreviatedMonthName(i));
            }


            // get the current data and use it to select a month and set the day and year
            DateTime now = DateTime.Now;
            monthSelect.SelectedIndex = now.Month - 1;
            dayInput.Value = now.Day.ToString();
            yearInput.Value = now.Year.ToString();

            // populate the athlete names
            eventTypeSelect.Items.Clear();
            foreach (string name in DataAccess.GetAthleteNames(context))
            {
                athleteSelect.Items.Add(name);
            }

            //populate the event types
            eventTypeSelect.Items.Clear();
            foreach (string name in DataAccess.GetEventTypeNames(context))
            {
                eventTypeSelect.Items.Add(name);
            }

        }
    }
}