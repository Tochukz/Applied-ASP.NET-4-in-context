using System.Collections.Generic;

namespace EventRegistration.Models.View
{
    public enum StartTime
    {
        Morning,
        Afternooon,
        Evening
    };

    public class CompetitionNames
    {
        public string EventName { get; set; }

        public IEnumerable<string> RegistrantNames { get; set; }
    }
}