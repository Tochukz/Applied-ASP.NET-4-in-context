using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EventRegistration.Models.View
{
    public enum StartTime
    {
        Morning,
        Afternooon,
        Evening
    };

    public class CompetitionSummary
    {
        [DisplayName("Event Name")]
        [UIHint("MultilineText")]
        public string Name { get; set; }
        
        [DisplayName("Location")]
        [UIHint("City")] // The argument 'City',  makes reference to a custom template helper defined in ~/Views/Shared/EditorTemplate/City.cshtml
        public string City { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [HiddenInput(DisplayValue=false)]
        //[HiddenInput(DisplayValue=true)]
        public bool Approved { get; set; }

        public StartTime Start { get; set; }
    }
}