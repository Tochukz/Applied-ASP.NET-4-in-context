using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkingWithRoutes.Models
{
    public class Customer
    {
        public int? Id { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }

    }
}