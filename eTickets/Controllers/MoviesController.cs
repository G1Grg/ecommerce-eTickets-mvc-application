using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service= service;
        }


        //****************************** Index *****************************//
        public async Task<IActionResult> Index()
        {
            //var allMovies = await _context.Movies.Include(n=>n.cinema).OrderBy(n=>n.Name).ToListAsync();
#pragma warning disable CS8603 // Possible null reference return.
            var allMovies = await _service.GetAllAsync(n => n.cinema);
#pragma warning restore CS8603 // Possible null reference return.
            return View(allMovies);
        }

        //****************************** Get: Movies/Details/1 *****************************//
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //****************************** Get: Movies/Create *****************************//
        public  IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our Store";
            ViewBag.Description = "Create a new Movie";
            return View();
        }


    }
}
