using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

                              
        [Required(ErrorMessage ="Name Required")]
        [StringLength(50)]
        [Display(Name ="Customer Name")]


        public string CustomerName { get; set; }
        [Display(Name ="Date of Birth")]
        [MinimumAge18(ErrorMessage ="Age Must Be 18")]
        public DateTime Dob { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name ="Membership Types")]
        public byte MembershipTypeId { get; set; }
        
    }
}