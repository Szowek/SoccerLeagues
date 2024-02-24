using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var teamStats = await _context.Teams
                .Select(team => new TeamStatisticsViewModel
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    MatchesPlayed = _context.Matches.Count(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId),
                    Wins = _context.Matches.Count(match => (match.FirstTeamId == team.TeamId && match.FirstTeamGoals > match.SecondTeamGoals) || (match.SecondTeamId == team.TeamId && match.SecondTeamGoals > match.FirstTeamGoals)),
                    Draws = _context.Matches.Count(match => (match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId) && match.FirstTeamGoals == match.SecondTeamGoals),
                    Losses = _context.Matches.Count(match => (match.FirstTeamId == team.TeamId && match.FirstTeamGoals < match.SecondTeamGoals) || (match.SecondTeamId == team.TeamId && match.SecondTeamGoals < match.FirstTeamGoals)),
                    GoalsScored = _context.Matches.Where(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId).Sum(match => team.TeamId == match.FirstTeamId ? match.FirstTeamGoals : match.SecondTeamGoals),
                    GoalsConceded = _context.Matches.Where(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId).Sum(match => team.TeamId == match.FirstTeamId ? match.SecondTeamGoals : match.FirstTeamGoals),
                    Points = _context.Matches.Count(match => (match.FirstTeamId == team.TeamId && match.FirstTeamGoals > match.SecondTeamGoals) || (match.SecondTeamId == team.TeamId && match.SecondTeamGoals > match.FirstTeamGoals)) * 3 +
                             _context.Matches.Count(match => (match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId) && match.FirstTeamGoals == match.SecondTeamGoals)
                })
                .OrderByDescending(teamStat => teamStat.Points)
                .ToListAsync();

            teamStats = teamStats.OrderByDescending(x => x.Points).ToList();
            for (int i = 0; i < teamStats.Count; i++)
            {
                teamStats[i].Position = i + 1;
            }

            return View(teamStats);

            //var leagueObj = await _leagueService.GetAll();
            //return View(leagueObj);
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