using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Database;
using SoccerLeagues.Entities.ModelsEntities;
using SoccerLeagues.Models;
using SoccerLeagues.Seeder;
using SoccerLeagues.Services;
using System.Diagnostics;
using System.Text;

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
            var teams = await _context.Teams.ToListAsync();
            var teamStats = new List<TeamStatisticsViewModel>();

            foreach (var team in teams)
            {
                var matchesPlayed = _context.Matches
                    .Count(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId);

                var wins = _context.Matches
                    .Count(match => (match.FirstTeamId == team.TeamId && match.FirstTeamGoals > match.SecondTeamGoals) || (match.SecondTeamId == team.TeamId && match.SecondTeamGoals > match.FirstTeamGoals));

                var draws = _context.Matches
                    .Count(match => (match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId) && match.FirstTeamGoals == match.SecondTeamGoals);

                var goalsScored = _context.Matches
                    .Where(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId)
                    .Sum(match => team.TeamId == match.FirstTeamId ? match.FirstTeamGoals : match.SecondTeamGoals);

                var goalsConceded = _context.Matches
                    .Where(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId)
                    .Sum(match => team.TeamId == match.FirstTeamId ? match.SecondTeamGoals : match.FirstTeamGoals);

                var points = (wins * 3) + draws;

                var lastResults = GetLastResults(team.TeamId);

                var teamStat = new TeamStatisticsViewModel
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    MatchesPlayed = matchesPlayed,
                    Wins = wins,
                    Draws = draws,
                    Losses = matchesPlayed - (wins + draws),
                    GoalsScored = goalsScored,
                    GoalsConceded = goalsConceded,
                    LastResults = lastResults,
                    Points = points
                };

                teamStats.Add(teamStat);
            }

            teamStats = teamStats.OrderByDescending(stat => stat.Points).ToList();
            for (int i = 0; i < teamStats.Count; i++)
            {
                teamStats[i].Position = i + 1;
            }

            return View(teamStats);

            //var leagueObj = await _leagueService.GetAll();
            //return View(leagueObj);
        }

        private string GetLastResults(int teamId)
        {
            var lastMatches = _context.Matches
                .Where(match => match.FirstTeamId == teamId || match.SecondTeamId == teamId)
                .OrderByDescending(match => match.MatchId)
                .ToList();

            StringBuilder lastResults = new StringBuilder();
            for (int i = 0; i < lastMatches.Count; i++)
            {
                var match = lastMatches[i];
                if ((match.FirstTeamId == teamId && match.FirstTeamGoals > match.SecondTeamGoals) || (match.SecondTeamId == teamId && match.SecondTeamGoals > match.FirstTeamGoals))
                {
                    lastResults.Append("Z");
                }
                else if (match.FirstTeamGoals == match.SecondTeamGoals)
                {
                    lastResults.Append("R");
                }
                else
                {
                    lastResults.Append("P");
                }
            }

            return lastResults.ToString();
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