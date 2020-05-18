using System.Linq;
using System.Web.Mvc;
using EventRegistration.Models.Domain;
using EventRegistration.Models.Domain.Repository;

/* A custom Model Binder
 */
namespace EventRegistration.Infrastructure
{
    public class RegistrationModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //This will populate the Registration object with values from the request
            Registration registration = (Registration)base.BindModel(controllerContext, bindingContext);
            registration.ID = int.Parse(GetValue(bindingContext, "ID", "0"));

            // The DependencyResolver.Current returns our NinJect dependecy resolver implementation
            IRepository repository = DependencyResolver.Current.GetService<IRepository>();

            registration.Competition = repository.Competitions.Where(c => c.ID == registration.CompetitionID).FirstOrDefault();
            return registration;
        }

        private string GetValue(ModelBindingContext context, string key, string defaultValue = null)
        {
            ValueProviderResult vpr = context.ValueProvider.GetValue(key);
            return vpr == null ? defaultValue : vpr.AttemptedValue; 
        }
    }
}