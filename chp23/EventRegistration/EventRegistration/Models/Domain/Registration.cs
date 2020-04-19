using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventRegistration.Models.Domain
{
    public class Registration
    {
        public string Name { get; set; }

        public string HomeCity { get; set; }

        public int Age { get; set; }

        public Competition Competition { get; set; }
            
    }
}