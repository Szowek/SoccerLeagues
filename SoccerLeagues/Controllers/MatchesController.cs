using Microsoft.AspNetCore.Mvc;
using SoccerLeagues.Database;
using SoccerLeagues.Models;
using System.Linq;

namespace SoccerLeagues.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var matches = _context.Matches.ToList();
            return View(matches);
        }
    }
}
