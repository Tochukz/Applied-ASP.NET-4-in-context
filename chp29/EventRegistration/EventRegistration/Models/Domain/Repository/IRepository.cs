using System.Collections.Generic;
using System.Linq;


namespace EventRegistration.Models.Domain.Repository
{
    public interface IRepository
    {
        IQueryable<Competition> Competitions { get;  }

        IQueryable<Registration> Registrations { get;  }

        void SaveCompetition(Competition comp);

        void SaveRegistration(Registration reg);
    }
}
