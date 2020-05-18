using System.Web.Mvc;
using System.Linq;
using EventRegistration.Models.Domain;
using EventRegistration.Models.Domain.Repository;
using EventRegistration.Infrastructure;
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
            // A new registration object is passed to the view to be used to make the view strongly typed.
            return View(new Registration());
        }


        /*
        // Hanlde POST request without Model Binding
        [HttpPost]
        public ActionResult HandleIndexPost()
        {
            Registration registration = new Registration();
            registration.Name = Request.Form["Name"];
            registration.Age = int.Parse(Request.Form["Age"]);
            registration.HomeCity = Request.Form["Homeity"];
            registration.CompetitionID = int.Parse(Request.Form["CompetitionID"]);
            
            registration.Competition = repository.Competitions.Where(c => c.ID == registration.CompetitionID).FirstOrDefault(); 
            repository.SaveRegistration(registration);
           
            return View("RegistrationComplete", registration);
        }
        */

        /*
        // Handle POST request with basic Binding using simple types
        [HttpPost]
        public ActionResult HandleIndexPost(string name, int age, string homecity, int Competitionid)
        {
            Registration registration = new Registration();
            registration.Name = name;
            registration.Age = age;
            registration.HomeCity = homecity;
            registration.CompetitionID = Competitionid;

            registration.Competition = repository.Competitions.Where(c => c.ID == registration.CompetitionID).FirstOrDefault();
            repository.SaveRegistration(registration);

            return View("RegistrationComplete", registration);
        }
        */

        // Handle POST request with BINDING to complex a type
        /*
        public ActionResult HandleIndexPost(Registration registration)
        {
            registration.Competition = repository.Competitions.Where(c => c.ID == registration.CompetitionID).FirstOrDefault();
            repository.SaveRegistration(registration);
            return View("RegistrationComplete", registration);
        }
        // We had to manually assign a value to the 'Competition' navigation property of the model object
        // We can have a custom model binder. We have custom model binder do it for us in the next example.
        */

        // This action uses the custom Model Binder implemeted in Infrastructure/RegistrationModelBinder and applied
        // to the Registration model class using class annotation
       public ActionResult HandleIndexPost(Registration registration)
       {
            // Property-Level validation to make sure that the Name property is unique in the databse table  
            if (ModelState.IsValidField("Name") && repository.Registrations.Where(x => x.Name == registration.Name).Count() > 0)
            {
                ModelState.AddModelError("Name", "A registation has already been made with this name");
            }

            //Model-Level Validation  
            if (ModelState.IsValidField("Age") && ModelState.IsValidField("CompetitionId"))
            {
                if (registration.Competition.Name == "Paris Panic" && registration.Age < 40)
                {
                    ModelState.AddModelError(string.Empty, "You must be at least 40 to do the Paris Panic");
                    // By using the empty string (string.Empty) as the property name, the MVC framework will know that the 
                    // problem is woth the overall model, rather than  an individual property.
                }
            }

            if (ModelState.IsValid)
            {
                repository.SaveRegistration(registration);
                return View("RegistrationComplete", registration);
            }
            else
            {
                ViewBag.Competitions = repository.Competitions;
                return View("Index", registration);
            }
           
       }
       // Unlike the action method before this which using the default model binding, the action does not need to assign value
       // to the navigation property of the model i.e the registration.Competition. This is taken care of by the custom model binder
        

    }
}