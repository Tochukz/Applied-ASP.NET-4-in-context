using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventRegistration.Models.Domain.Repository
{
    public class DummyRepository: IRepository
    {
        private static List<Registration> registrations = new List<Registration>();

        private static List<Competition> competitions = new List<Competition>()
        {
            new Competition { Name= "London Lunge", EventType = "Sprint", Location = "London", Date = new DateTime(2012, 4, 22)},
            new Competition { Name= "New York Nudge", EventType = "Olympic", Location = "New York", Date = new DateTime(2012, 5, 12), },
            new Competition { Name = "Paris Panic", EventType = "Sprint",Location = "Paris" , Date = new DateTime(2012, 5, 16)}
        };

        public IQueryable<Competition> Competitions
        {
            get
            {
                return competitions.AsQueryable();
            }
        }

        public void SaveCompetition(Competition competition)
        {
            competitions.Add(competition);
        }

        public IQueryable<Registration> Registrations
        {
            get
            {
                return registrations.AsQueryable();
            }
        }

        public void SaveRegistration(Registration registration)
        {
            registrations.Add(registration);
        }
    }
}