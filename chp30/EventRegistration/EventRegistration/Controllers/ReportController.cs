using System;
using System.Web.Mvc;
using EventRegistration.Models.Domain.Repository;
using System.Linq;

namespace EventRegistration.Controllers
{
    public class ReportController : Controller
    {
        private IRepository repository;

        public ReportController(IRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index(string competition)
        {
            ViewBag.CompetitionNames = repository.Competitions.Select(x => x.Name);
            if (string.IsNullOrEmpty(competition)) {
                return View((object)repository.Competitions.First().Name);
            } 
            else
            {
                return View((object)competition);
            }
        }

        public PartialViewResult RegistrationTable(string competition)
        {
            return PartialView(repository.Registrations.Where(x => x.Competition.Name == competition));
        }
    }
}