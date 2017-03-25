using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Movie_Rental_Store_Management_System.ViewModel
{
    public class ViewModel_NewRental
    {
        public int? customerid { get; set; }
        public List<int?> movieIds { get; set; }

    }
}