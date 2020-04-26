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

        public ActionResult List(int? id)
        {
            ViewBag.Time = DateTime.Now;
            if (id.HasValue)
            {
                return View(repository.Registrations.OrderBy(x => x.ID).Skip(id.Value - 1).Take(1));
            } 
            else
            {
                return View(repository.Registrations);
            }
            
        }
    }
}