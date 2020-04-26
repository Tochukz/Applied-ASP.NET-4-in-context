using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventRegistration.Models.Domain
{
    public class Registration
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string HomeCity { get; set; }

        public int Age { get; set; }

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