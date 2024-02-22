using Microsoft.AspNetCore.Mvc;
using SoccerLeagues.Database;
using SoccerLeagues.Models;
using System.Linq;

namespace SoccerLeagues.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }
    }
}
