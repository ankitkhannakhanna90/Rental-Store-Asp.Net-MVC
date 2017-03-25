using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
//using System.Linq;
using Movie_Rental_Store_Management_System.Models;
using Movie_Rental_Store_Management_System.ViewModel;

namespace Movie_Rental_Store_Management_System.Controllers
{   
    public class NewRentalsController : Controller
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: NewRentals
        [Route("NewRentalForm")]
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult AddRentalForm(ViewModel_NewRental newrental)
        {
            //var check = newrental;
            var customer = _context.Customers.SingleOrDefault(c => c.Id ==newrental.customerid);
            var movies = _context.Movies.Where(c => newrental.movieIds.Contains(c.Id)).ToList();
            foreach(var movie in movies)
            {
                var rental = new NewRental()
                {
                    Customer=customer,
                    Movie=movie,
                    DateRented=DateTime.Now

                };
                _context.NewRentals.Add(rental);
            }
            _context.SaveChanges();
            return Json(new { success = true });
        }

    }
}