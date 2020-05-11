using System;
using System.Collections.Generic;

namespace EventRegistration.Models.Domain
{
    public class Competition
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string EventType { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}