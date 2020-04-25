using System.Web.Mvc;
using System.Linq;
using EventRegistration.Models.Domain;
using EventRegistration.Models.Domain.Repository;
using System.Dynamic;
using System;

namespace EventRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        readonly IRepository repository; 

        public RegistrationController(IRepository repo)
        {

            repository = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Competitions = repository.Competitions;
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Registration registration)
        {
            repository.SaveRegistration(registration);
            return View("RegistrationComplete", registration);
        }

        public ActionResult List()
        {
            /* preparing dynamic object*/
            dynamic dynamicObj = new ExpandoObject();
            dynamicObj.Data = repository.Registrations;
            dynamicObj.ItemCount = repository.Registrations.Count();
            /* This can be used for wealkly typed view */

            ViewBag.Time = DateTime.Now;
            return View(repository.Registrations);
        }
    }
}