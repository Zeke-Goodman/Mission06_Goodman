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
            ViewBag.CategoryList = _context.Categories.ToList();
            return View();
        }

        // Action method for submitting movie data (HTTP POST)
        [HttpPost]
        public IActionResult movies(Movie response)
        {
            // Add movie data to the database
            _context.Movies.Add(response);
            _context.SaveChanges();

            // Redirect to the movies page with the submitted movie data
            return View("movies", response);
        }

        [HttpGet]
        public IActionResult AllMovies()
        { 
            var GetMovies = _context.Movies.Include("Category")
                .ToList();

            return View(GetMovies);
        }



    }
}
