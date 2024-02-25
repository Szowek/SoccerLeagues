using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Database;
using SoccerLeagues.Entities.ModelsEntities;

namespace SoccerLeagues.Controllers
{
    [Authorize]
    public class FavoriteTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public FavoriteTeamsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            var existingFavoriteTeam = await _context.FavoriteTeams.FirstOrDefaultAsync(ft => ft.UserId == currentUser.Id && ft.TeamId == id);
            if (existingFavoriteTeam != null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            var favoriteTeam = new FavoriteTeam
            {
                UserId = currentUser.Id,
                TeamId = id
            };
            _context.Add(favoriteTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var favoriteTeam = await _context.FavoriteTeams.FirstOrDefaultAsync(ft => ft.UserId == currentUser.Id && ft.TeamId == id);
            if (favoriteTeam == null)
            {
                return NotFound();
            }

            _context.FavoriteTeams.Remove(favoriteTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Teams));
        }

        public async Task<IActionResult> Teams()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var favoriteTeams = await _context.FavoriteTeams
                .Where(ft => ft.UserId == currentUser.Id)
                .Include(ft => ft.Team)
                .ToListAsync();

            return View(favoriteTeams);
        }
    }
}