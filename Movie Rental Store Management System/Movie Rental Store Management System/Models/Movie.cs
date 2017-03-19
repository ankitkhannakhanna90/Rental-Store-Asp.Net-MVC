using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Store_Management_System.Models
{
    public class Movie
    {
        public int? Id { get; set; }
        [Required (ErrorMessage="Enter The Name Of Movie")]
        
        public string Name { get; set; }
        [Required(ErrorMessage="Release Date of Movie??")]
        [Display(Name="Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "  Date of Movie??")]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Required(ErrorMessage = "Enter the Stock")]
        public byte Stock { get; set; }
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Select the Genre")]
        [Display(Name = "Genre ")]
        public int GenreId { get; set; }


    }
}