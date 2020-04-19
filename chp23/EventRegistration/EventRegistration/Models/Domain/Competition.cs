using System;

namespace EventRegistration.Models.Domain
{
    public class Competition
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string EventType { get; set; }
    }
}