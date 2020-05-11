using System;
using System.Web.Mvc;
using EventRegistration.Models.Domain.Repository;

namespace EventRegistration.Controllers
{
    public class ReportController : Controller
    {
        private IRepository repository;

        public ReportController(IRepository repo)
        {
            repository = repo;
        }

        /* Display the FormatError view when a FormatException goes unhandled by this action method*/
        [HandleError(ExceptionType=typeof(FormatException), View = "FormatError")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string report)
        {
            switch(report)
            {
                case "Competitions":
                    return View("CompetitionREport", repository.Competitions);
                case "Registrations":
                    return View("RegistrationReport", repository.Registrations);
                default:
                    return View();
            }
        }
    }
}