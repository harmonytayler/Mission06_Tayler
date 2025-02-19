using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("AddMovie", new Movie());
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("ConfirmAdd", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();
                return View(response);
            }
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            return View("AddMovie", record);
        }

        [HttpPost]
        public IActionResult Edit(Movie app)
        {
            _context.Movies.Update(app);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _context.Movies
                .Single(x => x.MovieId == id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(Movie app)
        {
            _context.Movies.Remove(app);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
