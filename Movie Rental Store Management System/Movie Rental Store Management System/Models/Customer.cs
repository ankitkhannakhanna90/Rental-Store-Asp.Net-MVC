using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental_Store_Management_System.Models;
using System.ComponentModel.DataAnnotations;
namespace Movie_Rental_Store_Management_System.Models
{
    public class Customer
    {
        public int? Id { get; set; }
        [Display(Name="Name ")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name="Date Of Birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Display(Name="Wanna Subscribe To News Letter")]
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    
    
    }
}