using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mission06_Tayler.Models;

namespace Mission06_Tayler.Controllers
{
    // THIS COMMENT IS BEING ADDED TO THE NEW BRANCH
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("ConfirmAdd", response);
        }
    }
}
