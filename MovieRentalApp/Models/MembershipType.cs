using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInmonths { get; set; }
        public int DiscountRate { get; set; }
        public string Type { get; set; }
    }
}