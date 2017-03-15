using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental_Store_Management_System.Models
{
    public class Movie
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public byte Stock { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }


    }
}