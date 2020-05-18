using System;
using System.Web.Mvc;
using System.Linq;
using EventRegistration.Models.Domain;
using EventRegistration.Models.View;
using EventRegistration.Models.Domain.Repository;
using System.Collections.Generic;

namespace EventRegistration.Controllers
{
    public class CompetitionController : Controller
    {
        private IRepository repository;

        public CompetitionController(IRepository repo)
        {
            repository = repo;
        }


        public ViewResult Index()
        {
            return View(repository.Competitions);
        }

        public void NoFutherAction()
        {
            /* By convention a GET request should only read data and NOT modify data 
             * This violates that convention but it is used only for demonstration.
             */
            foreach(Competition comp in repository.Competitions.ToArray())
            {
                comp.Date = comp.Date.AddMonths(1);
                repository.SaveCompetition(comp);
            }
        }

        public string Time()
        {
            return string.Format("The time is {0}", DateTime.Now.ToShortTimeString());
        }

        public RedirectToRouteResult RedirectToIndex()
        {
            //return RedirectToAction("Index");
             return RedirectToAction("Index", "Home"); //Redirect to Action on a different controller i.e HomeController
        }

        public RedirectResult RedirectLiteral()
        {
            return Redirect("http://tochukwu.xyz");
           
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(403, "You can Forbidded here!");
        }

        /* Return status code 44*/
        public HttpStatusCodeResult NotFound()
        {
            return HttpNotFound();
        }

        public HttpStatusCodeResult UnAuthorized()
        {
            return new HttpUnauthorizedResult();
        }

        public ViewResult Registrants()
        {
            IList<CompetitionNames> names = new List<CompetitionNames>();
            foreach (Competition comp in repository.Competitions.ToArray())
            {
                names.Add(new CompetitionNames {
                    EventName = comp.Name,
                    RegistrantNames = comp.Registrations.Select(e => e.Name).Distinct()
                });
            }
            ViewBag.Time = DateTime.Now.ToShortTimeString();

            return View(names);
        }

        /* The ChildActionOnly attribute is used to prevent the action from being onvoked as a result of a user request
         * The ChildActionOnly attribute is not required for the method to be used as a child action.
         */
        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            ViewBag.CompCount = repository.Competitions.Count();
            ViewBag.RegCount = repository.Registrations.Count();
            return PartialView(DateTime.Now);
        }
    }
}