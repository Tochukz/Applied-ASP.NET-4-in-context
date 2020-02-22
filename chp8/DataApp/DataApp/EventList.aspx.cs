using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace DataApp
{
    public partial class EventList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // create the entity data model context object
            using (TrainingDataEntities context = new TrainingDataEntities())
            {
                // populate the select control if needed
                if (ViewState["setupComplete"] == null)
                {
                    foreach( string name in context.EventTypes.Select(item => item.Name))
                    {
                        eventSelector.Items.Add(name);
                    }
                    ViewState["setupComplete"] = true;
                }
                // define the collection of events that we will process
                IEnumerable<Event> eventsToProcess;

                if (IsPostBack && eventSelector.Value != "All")
                {
                    // perform a LINQ query to filter the data
                    /*
                    eventsToProcess = from item in context.Events
                                      where item.Type == eventSelector.Value
                                      select item;
                    */
                    eventsToProcess = DataAccess.GetEventsByType(context, eventSelector.Value);
                } 
                else
                {
                    /* eventsToProcess = context.Events; */
                    eventsToProcess = DataAccess.GetAllEvents(context);
                }


                // enumerate the objects in the context.Events property - these correspond to the rows in the Events table in the database 
                foreach (Event ev in eventsToProcess)
                {
                    /*
                    int personalRank = new RankingSet(
                          context.GetPersonalRanking1(ev.Athlete, ev.Type, ev.SwimTime, ev.CycleTime, ev.RunTime, ev.OverallTime)
                       ).OverallRank;
                    int referenceRank = new RankingSet(
                          context.GetReferenceRanking1(ev.Type, ev.SwimTime, ev.CycleTime, ev.RunTime, ev.OverallTime)
                        ).OverallRank;
                    */
                    int personalRank = DataAccess.GetPersonalRanking(context, ev).OverallRank;

                    int referenceRank = DataAccess.GetReferenceRanking(context, ev).OverallRank;

                    // process the enitity object
                    ProcessEvent(ev, personalRank, referenceRank);
                }
            }
        }

        private void ProcessEvent(Event eventParam, int personalRankParam, int referenceRankParam)
        {
            HtmlTableRow row = new HtmlTableRow();

            row.Cells.Add(CreateTableCell(eventParam.Date.ToString("MM/dd")));
            row.Cells.Add(CreateTableCell(eventParam.Athlete));
            row.Cells.Add(CreateTableCell(eventParam.Type));
            row.Cells.Add(CreateTableCell(eventParam.SwimTime.ToString()));
            row.Cells.Add(CreateTableCell(eventParam.CycleTime.ToString()));
            row.Cells.Add(CreateTableCell(eventParam.RunTime.ToString()));
            row.Cells.Add(CreateTableCell(eventParam.OverallTime.ToString()));

            // add the ranking information
            row.Cells.Add(CreateTableCell(personalRankParam.ToString()));
            row.Cells.Add(CreateTableCell(referenceRankParam.ToString()));

            // add link cells 
            row.Cells.Add(CreateLinkTableCell("/UpdateOrDeleteEvent.aspx", "Edit", eventParam.ID, "edit"));
            row.Cells.Add(CreateLinkTableCell("/UpdateOrDeleteEvent.aspx", "Delete", eventParam.ID, "delete"));

            resultsTable.Rows.Add(row);
        }

        private HtmlTableCell CreateTableCell(string textParam)
        {
            return new HtmlTableCell() { InnerText = textParam };
        }

        public HtmlTableCell CreateLinkTableCell(string urlParam, string textParam, int idParam, string modeParam)
        { 
            HtmlAnchor anchor = new HtmlAnchor() { 
                HRef = string.Format("{0}?id={1}&mode={2}", urlParam, idParam, modeParam), 
                InnerText = textParam 
            };
            HtmlTableCell cell = new HtmlTableCell();
            cell.Controls.Add(anchor);

            return cell;
        }
    }
}

/**
 *  The using(){...} block is the simplest and most reliable way of disposing the context object as soon as it not needed anymore
 *  The context object will be disposed as soon as it is out of scope.  
 *  This is to ensure the the application can scale properly.  
 *  Do not be tempted to create a single context object and share it betweeen requests. This causes problems when modification to the database causes errors.
 */