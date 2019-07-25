using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}