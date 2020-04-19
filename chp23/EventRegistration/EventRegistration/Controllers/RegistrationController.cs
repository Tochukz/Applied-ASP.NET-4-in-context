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
            // This should be avoid in real project because it creates a dependency between 
            // the controller and the repository implementation.  
            // repository = new DummyRepository();

            repository = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Competitions = repository.Competitions.Select(c => c.Name);
            return View();
        }
        
        /*
        [HttpPost]
        public ActionResult Index(string name, string homecity, string age, string competition)
        {
            Registration registration = new Registration
            {
                Name = name,
                HomeCity = homecity,
                Age = int.Parse(age),
                Competition = repository.Competitions.Where(e => e.Name == competition).FirstOrDefault(),
            };
            repository.SaveRegistration(registration);

            return View("RegistrationComplete", registration);
        }
        */

        /* Using model binding */
        [HttpPost]
        public ActionResult Index(Registration registration, string competition)
        {
            registration.Competition = repository.Competitions.Where(e => e.Name == competition).FirstOrDefault();
            repository.SaveRegistration(registration);
            return View("RegistrationComplete", registration);
        }
    }
}