using Microsoft.AspNetCore.Mvc;
using SoccerLeagues.Database;
using SoccerLeagues.Entities.ModelsEntities;
using SoccerLeagues.Models;
using SoccerLeagues.Seeder;
using SoccerLeagues.Services;
using System.Diagnostics;

namespace SoccerLeagues.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ILeagueService _leagueService;
        private readonly ILeagueLog _leagueLog;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ILeagueService leagueService, ILeagueLog leagueLog)
        {
            _logger = logger;
            _leagueService = leagueService;
            _leagueLog = leagueLog;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var leagueObj = await _leagueService.GetAll();
            return View(leagueObj);
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