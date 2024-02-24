using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using ZekeGoodmanMission6.Models;

namespace ZekeGoodmanMission6.Controllers
{
    // HomeController class handles requests related to home and movies
    public class HomeController : Controller
    {
        // Database context for accessing movie data
        private MovieDbContext _context;

        // Constructor for HomeController, initializes MovieDbContext
        public HomeController(MovieDbContext temp)
        {
            _context = temp;
        }

        // Action method for rendering the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action method for rendering the meetJoel page
        public IActionResult meetJoel()
        {
            return View();
        }

        // Action method for rendering the movies page (HTTP GET)
        [HttpGet]
        public IActionResult movies()
        {
            // Fetches categories to populate dropdown in the view
            ViewBag.CategoryList = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();
            return View(new Movie());
        }

        // Action method for submitting movie data (HTTP POST)
        [HttpPost]
        public IActionResult movies(Movie response)
        {
            if (ModelState.IsValid)
            {
                // Add movie data to the database
                _context.Movies.Add(response);
                _context.SaveChanges();

                // Redirects to the movies page with the submitted movie data
                return RedirectToAction("movies");
            }
            else
            {
                // If model validation fails, reloads the page with existing data and error messages
                ViewBag.CategoryList = _context.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();
                return View(response);
            }
        }

        // Action method for displaying all movies
        [HttpGet]
        public IActionResult AllMovies()
        {
            // Retrieves all movies including their corresponding category information
            var GetMovies = _context.Movies.Include("Category")
                .ToList();

            return View(GetMovies);
        }

        // Action method for editing a movie (HTTP GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieves the movie record to be edited
            var RecordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            // Fetches categories to populate dropdown in the view
            ViewBag.CategoryList = _context.Categories.OrderBy(x => x.CategoryId).ToList();

            return View("movies", RecordToEdit);
        }

        // Action method for updating movie information (HTTP POST)
        [HttpPost]
        public IActionResult Edit(Movie UpdatedInfo)
        {
            // Updates the movie information
            _context.Update(UpdatedInfo);
            _context.SaveChanges();

            return RedirectToAction("AllMovies");
        }

        // Action method for displaying confirmation page for movie deletion (HTTP GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Retrieves the movie record to be deleted
            var RecordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(RecordToDelete);
        }

        // Action method for deleting a movie (HTTP POST)
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            // Removes the movie from the database
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("AllMovies");
        }
    }
}
