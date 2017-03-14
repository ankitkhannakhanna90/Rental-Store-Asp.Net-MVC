using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental_Store_Management_System.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
        public byte DurationInMonths { get; set; }
        public byte SignUpFee { get; set; }
    }
}