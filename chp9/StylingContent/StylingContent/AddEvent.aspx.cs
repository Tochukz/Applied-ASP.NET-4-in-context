using System;
using System.Globalization;

namespace StylingContent
{
    public partial class AddEvent : System.Web.UI.Page
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

                if (IsPostBack)
                {
                    try
                    {
                        int day = int.Parse(dayInput.Value);
                        int month = monthSelect.SelectedIndex + 1;
                        int year = int.Parse(yearInput.Value);
                        DataAccess.AddEvent(
                            context,
                            new DateTime(year, month, day),
                            athleteSelect.Value,
                            eventTypeSelect.Value,
                            TimeSpan.Parse(swimTimeInput.Value),
                            TimeSpan.Parse(cycleTimeInput.Value),
                            TimeSpan.Parse(runTimeInput.Value)
                        );

                        Response.Redirect("EventList.aspx");
                    }
                    catch (FormatException)
                    {
                        errorDiv.InnerText = "Cannot parse inputs";
                    }
                    catch (InvalidOperationException ex)
                    {
                        errorDiv.InnerText = "Invalid Operation Exception: " + ex.Message;
                    }
                    catch (ArgumentNullException ex)
                    {
                        errorDiv.InnerText = "ArgumentNull Exception " + ex.Message;
                    }
                    catch (OverflowException ex)
                    {
                        errorDiv.InnerHtml = string.Format("<p>{0}</p> <p>{1}</p>", ex.Message, ex.Source);
                    }
                    catch (Exception ex)
                    {
                        errorDiv.InnerText = string.Format("<p>{0}</p> <p>{1}</p> <p>{2}</p>", ex.InnerException.Message, ex.InnerException.StackTrace, ex.InnerException.ToString());
                    }

                }
            }
        }

        private void PerformPageSetup(TrainingDataEntities context)
        {
            DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
            monthSelect.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                monthSelect.Items.Add(formatInfo.GetAbbreviatedMonthName(i));
            }

            // get the current date and use it to select a month and set the day and year
            DateTime now = DateTime.Now;
            monthSelect.SelectedIndex = now.Month - 1;
            dayInput.Value = now.Day.ToString();
            yearInput.Value = now.Year.ToString();

            // populate the athlete names
            athleteSelect.Items.Clear();
            foreach (string name in DataAccess.GetAthleteNames(context))
            {
                athleteSelect.Items.Add(name);
            }

            // populate the event types
            eventTypeSelect.Items.Clear();
            foreach (string name in DataAccess.GetEventTypeNames(context))
            {
                eventTypeSelect.Items.Add(name);
            }
        }
    }
}