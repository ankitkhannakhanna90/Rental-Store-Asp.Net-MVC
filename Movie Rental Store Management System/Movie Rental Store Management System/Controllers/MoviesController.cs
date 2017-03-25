using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_Rental_Store_Management_System.Models;
using Movie_Rental_Store_Management_System.ViewModel;
using System.Data.Entity;

namespace Movie_Rental_Store_Management_System.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        { 
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            if (!User.IsInRole("SuperAdmin")&&!User.IsInRole("Admin")&&!User.IsInRole("CanChangeMovies"))
                return View("Index", movie);
            else
                return View("(Master1)Index", movie);
        }
        [Authorize(Roles="SuperAdmin,Admin,CanChangeMovies")]
        
        public ActionResult CreateMovie()
        {
            var viewmodel = new ViewModel_MoviesGenres()
                {
                    Genre=_context.Genres.ToList()
                };
            return View(viewmodel);
        }
        public ActionResult AddMovie(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new ViewModel_MoviesGenres()
                {
                    Movie = Movie,
                    Genre = _context.Genres.ToList()

                };
                return View("CreateMovie", viewmodel);
            }
            else
            {
                if (Movie.Id == null)
                {
                    _context.Movies.Add(Movie);
                }
                else
                {
                    var movie = _context.Movies.SingleOrDefault(c => c.Id == Movie.Id);
                    movie.Name = Movie.Name;
                    movie.ReleaseDate = Movie.ReleaseDate;
                    movie.DateAdded = Movie.DateAdded;
                    movie.Stock = Movie.Stock;
                    movie.GenreId = Movie.GenreId;

                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");     
            }
           
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var viewmodel = new ViewModel_MoviesGenres()
            {
                Movie=movie,
                Genre=_context.Genres.ToList()
            };

            return View("CreateMovie", viewmodel);
        }
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }
        public JsonResult GetMoviesData(string query = null)
        {
            var moviequery = _context.Movies.Include(c => c.Genre);
            if (!string.IsNullOrWhiteSpace(query))
                moviequery = moviequery.Where(c => c.Name.Contains(query));


            var movies = moviequery.ToList();
            return Json(movies, JsonRequestBehavior.AllowGet);

        }
        
    }
}