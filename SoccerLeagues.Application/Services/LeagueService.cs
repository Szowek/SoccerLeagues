using SoccerLeagues.Entities.ModelsEntities;

namespace SoccerLeagues.Services
{
    public interface ILeagueService
    {
        Task CreateService(SoccerLeagues.Entities.ModelsEntities.League league);
        Task<IEnumerable<SoccerLeagues.Entities.ModelsEntities.League>> GetAll();
    }

    public class LeagueService : ILeagueService
    {
        private readonly ILeagueLog _league;

        public LeagueService(ILeagueLog league)
        {
            _league = league;
        }

        public async Task CreateService(League league)
        {
            await _league.CreateLog(league);
        }

        public async Task<IEnumerable<League>> GetAll()
        {
            var leagues = await _league.GetAll();
            return leagues;
        }
    }

    public class LeagueTableService
    {
        public List<LeagueTableRow> GenerateLeagueTable(List<Team> teams, List<Match> matches)
        {
            List<LeagueTableRow> leagueTable = new List<LeagueTableRow>();

            foreach (var team in teams)
            {
                var teamMatches = matches.Where(match => match.FirstTeamId == team.TeamId || match.SecondTeamId == team.TeamId)
                                         .OrderByDescending(match => match.MatchId)
                                         .ToList();

                int totalMatches = teamMatches.Count;
                int wins = teamMatches.Count(match => (match.FirstTeamId == team.TeamId && match.FirstTeamGoals > match.SecondTeamGoals) ||
                                                       (match.SecondTeamId == team.TeamId && match.SecondTeamGoals > match.FirstTeamGoals));
                int draws = teamMatches.Count(match => match.FirstTeamGoals == match.SecondTeamGoals);
                int losses = totalMatches - wins - draws;
                int goalsScored = teamMatches.Sum(match => match.FirstTeamId == team.TeamId ? match.FirstTeamGoals : match.SecondTeamGoals);
                int goalsConceded = teamMatches.Sum(match => match.FirstTeamId == team.TeamId ? match.SecondTeamGoals : match.FirstTeamGoals);
                int goalDifference = goalsScored - goalsConceded;
                int points = (wins * 3) + draws;

                leagueTable.Add(new LeagueTableRow
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    TotalMatches = totalMatches,
                    Wins = wins,
                    Draws = draws,
                    Losses = losses,
                    GoalsScored = goalsScored,
                    GoalsConceded = goalsConceded,
                    GoalDifference = goalDifference,
                    Points = points
                });
            }

            // Sortuj tabelę ligową według liczby punktów w kolejności malejącej
            leagueTable = leagueTable.OrderByDescending(row => row.Points).ToList();

            return leagueTable;
        }
    }

    public class LeagueTableRow
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TotalMatches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
    }
}
