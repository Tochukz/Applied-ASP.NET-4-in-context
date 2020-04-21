using System.Web.Mvc;
using System.Linq;
using EventRegistration.Models.Domain;
using EventRegistration.Models.Domain.Repository;

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
    }
}