using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;
using System.Reflection;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "MovieShop Home Page Title";
            //ViewData["Title"] = "MovieShop Home Page Title";
            //ViewBag.description = new List<string>() { "abc", "def"};
            var movies = new List<MovieCard>
            {
                new MovieCard { Title = "Inception", Id = 1, PosterUrl = "https://image.tmdb.org/t/p/w342/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg" },
                new MovieCard { Title = "Interstellar", Id = 2, PosterUrl = "https://image.tmdb.org/t/p/w342/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg" },
                new MovieCard { Title = "The Dark Knight", Id = 3, PosterUrl = "https://image.tmdb.org/t/p/w342/qJ2tW6WMUDux911r6m7haRef0WH.jpg" },
                new MovieCard { Title = "Deadpool", Id = 4, PosterUrl = "https://image.tmdb.org/t/p/w342/yGSxMiF0cYuAiyuve5DA6bnWnBw.jpg" },
                new MovieCard { Title = "The Avengers", Id = 5, PosterUrl = "https://image.tmdb.org/t/p/w342/RYMX2wcKCBAr24UyPD7xwmjaTn.jpg" }
            };

            return View(movies);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
