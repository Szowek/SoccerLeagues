using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Database;
using SoccerLeagues.Entities.ModelsEntities;
using SoccerLeagues.Models;
using SoccerLeagues.MVC.Areas.Identity.Data;
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
            var teamsStats = new Dictionary<string, List<TeamStatisticsViewModel>>();

            foreach (var phase in _context.LeaguePhases.Include(p => p.TeamsInLeaguePhase))
            {
                var teamStats = new List<TeamStatisticsViewModel>();

                var leagueName = _context.Leagues
                .Where(l => l.PhasesInLeague.Any(p => p.LeaguePhaseId == phase.LeaguePhaseId))
                .Select(l => l.LeagueName)
                .FirstOrDefault();

                foreach (var team in phase.TeamsInLeaguePhase)
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
                        LeagueName = leagueName,
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

                teamsStats.Add(phase.LeaguePhaseName, teamStats);
            }

            return View(await Task.FromResult(teamsStats));
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

        [HttpGet]
        public IActionResult GetMatchesForTeam(string teamName)
        {
            var matches = _context.Matches
                .Where(match => match.FirstTeam.TeamName == teamName || match.SecondTeam.TeamName == teamName)
                .Select(match => new {
                    Opponent = (match.FirstTeam.TeamName == teamName) ? match.SecondTeam.TeamName : match.FirstTeam.TeamName,
                    Score = (match.FirstTeam.TeamName == teamName) ? $"{match.FirstTeamGoals} - {match.SecondTeamGoals}" : $"{match.SecondTeamGoals} - {match.FirstTeamGoals}",
                    Result = (match.FirstTeam.TeamName == teamName) ?
                        (match.FirstTeamGoals > match.SecondTeamGoals ? "Wygrana" : (match.FirstTeamGoals < match.SecondTeamGoals ? "Porażka" : "Remis")) :
                        (match.SecondTeamGoals > match.FirstTeamGoals ? "Wygrana" : (match.SecondTeamGoals < match.FirstTeamGoals ? "Porażka" : "Remis"))
                })
                .ToList();
            return Json(matches);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}