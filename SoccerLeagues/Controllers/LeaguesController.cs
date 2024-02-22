using Microsoft.AspNetCore.Mvc;
using SoccerLeagues.Database;
using SoccerLeagues.Models;
using System.Linq;

namespace SoccerLeagues.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaguesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leagues = _context.Leagues.ToList();
            return View(leagues);
        }
    }
}
