using System.Data.Entity;
using System.Linq;

namespace EventRegistration.Models.Domain.Repository
{
    public class EFRepository : IRepository
    {
        private EFAdapter adapter = new EFAdapter("EFRepository");

        public IQueryable<Competition> Competitions
        {
            get
            {
                return adapter.Competitions;
            }
        }

        public IQueryable<Registration> Registrations
        {
            get
            {
                return adapter.Registrations;

                /* For 'eager loading', use the Include method */
               // return adapter.Registrations.Include("Competitions");
            }
        }

        public void SaveRegistration(Registration reg)
        {
            if (reg.ID == 0)
            {
                adapter.Registrations.Add(reg);
                /* The is to ensure that the Competition navigation property is loaded with the Competition model for the newly created model
                 * This is useful in cases where the newly created model is passed to a view and it's Navigation property is read.
                 */
                adapter.Entry(reg).Reference("Competition").Load();
            }
            adapter.SaveChanges();
        }

        public void SaveCompetition(Competition comp)
        {
            if (comp.ID == 0)
            {
                adapter.Competitions.Add(comp);
                adapter.Entry(comp).Collection("Registrations").Load();
            }
            adapter.SaveChanges();
        }
    }
}