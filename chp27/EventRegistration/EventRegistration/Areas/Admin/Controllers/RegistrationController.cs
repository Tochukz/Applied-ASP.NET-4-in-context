using System.Linq;
using System.Web.Mvc;
using EventRegistration.Models.Domain.Repository;

namespace EventRegistration.Areas.Admin.Controllers
{
    public class RegistrationController : Controller
    {
        private IRepository repository;

        public RegistrationController(IRepository repo)
        {
            repository = repo;
        }

        // GET: Admin/Registration
        public ActionResult Index()
        {
            return View(repository.Registrations.Count());
        }
    }
}