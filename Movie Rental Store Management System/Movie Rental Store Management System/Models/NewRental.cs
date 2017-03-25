using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Movie_Rental_Store_Management_System.Models
{
    public class NewRental
    {

        public int id { get; set; }
        public Customer Customer { get; set; }
       // public int CustomerId { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    //public int MovieId { get; set; }




    }
}