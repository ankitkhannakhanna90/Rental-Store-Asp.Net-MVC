using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental_Store_Management_System.Models;
namespace Movie_Rental_Store_Management_System.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    
    
    }
}