using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rental_Store_Management_System.Models;

namespace Movie_Rental_Store_Management_System.ViewModel
{
    public class ViewModel_MoviesGenres
    {
        public Movie Movie { get; set; }
        public List<Genre> Genre { get; set; }
        public string Title {
            get
            {
                if (Movie == null)
                    return "New Movie";
                else
                    return "Edit Movie";
            }
        }
    }
}