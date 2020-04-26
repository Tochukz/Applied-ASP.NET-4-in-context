using System.Web.Mvc;
using EventRegistration.Models.View;

namespace EventRegistration.Controllers
{
    public class CompetitionController : Controller
    {
        // GET: Competition
        public ActionResult Summary()
        {
            CompetitionSummary summary = new CompetitionSummary
            {
                Name = "Mass Mangler",
                City = "Boston",
                Date = new System.DateTime(2012, 1, 20),
                Approved = true,
                Start = StartTime.Afternooon
            };

            return View(summary);
        }

        public ActionResult Athlete()
        {
            AthleteDetails athlete = new AthleteDetails
            {
                Name = "John smith",
                Age = 29,
                City = "Boston"
            };

            return View(athlete);
        }
    }
}