using Microsoft.AspNetCore.Mvc;
using SoccerLeagues.Database;
using SoccerLeagues.Models;
using SoccerLeagues.Seeder;
using System.Diagnostics;

namespace SoccerLeagues.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //TODO MOVE TO Program.cs
        private readonly ApplicationDbContext _context; //TODO MOVE TO Program.cs
        private readonly SoccerLeaguesSeeder _seeder;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger; //TODO MOVE TO Program.cs
            _context = context; //TODO MOVE TO Program.cs
            _seeder = new SoccerLeaguesSeeder(context);
        }

        public IActionResult Index()
        {
            _seeder.SeedData(); //TODO MOVE TO Program.cs
            return View();
        }

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