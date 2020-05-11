using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using EventRegistration.Infrastructure;

namespace EventRegistration.Models.Domain
{
    // Applying our Custom Binder to the model
    [ModelBinder(typeof(RegistrationModelBinder))]
    public class Registration
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string HomeCity { get; set; }

        [Required(ErrorMessage ="Please enter an age")]
        [Range(18, 100, ErrorMessage = "Please enter age between 18 and 100")]
        public int Age { get; set; }

        [Required]
        public int CompetitionID { get; set; }

        /* Competition is an example of a 'Navigation property'. We can use it to navigate to the Competition model assoiated with the Registration. 
         * Since the property was defined using the 'virtual' modifier, entity framework will use lazy loading to load this associated model.
         */
        public virtual Competition Competition { get; set; }

        /* The alternative to 'Lazy loading' is 'Eager loading'.  
         * Eager loading is done by using the Include method in the Repository implementation. See EFRepository class.
         */
            
    }
}