using System.Linq;
using System.Data.Entity;

namespace EventRegistration.Models.Domain.Repository
{
    public class EFAdapter : DbContext
    {
        public EFAdapter(string connectionStringName) : base(connectionStringName)
        {
            // If the connectionStringName was not passed to the base class constructor, EF will use the name of this class as the connectionStringName which is EFAdapter
        }

        /* Tells Entity Framework that rows in the Competitions tabnle should be represented by the Competition model class*/
        public DbSet<Competition> Competitions { get; set; } 

        public DbSet<Registration> Registrations { get; set; }
    }
}