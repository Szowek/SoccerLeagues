using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Database;
using SoccerLeagues.Entities.ModelsEntities;

namespace SoccerLeagues.Seeder
{
    public class SoccerLeaguesSeeder
    {
        private readonly ApplicationDbContext _context;
        public SoccerLeaguesSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if (await _context.Database.CanConnectAsync())
            {
                //if (!_context.Leagues.Any())
                //{

                string[] phaseNames = { "Sezon Zasadniczy", "Play-Off. Strefa Mistrzowska.", "Conference League Play-Off" };
                var league1 = new League()
                {
                    LeagueName = "Belgijska Pro League 2022/2023",
                    PhasesInLeague = new List<LeaguePhase>()
                };

                foreach (var phaseName in phaseNames)
                {
                    var phase = new LeaguePhase()
                    {
                        LeaguePhaseName = phaseName,
                        TeamsInLeaguePhase = new List<Team>(),
                        MatchesInLeaguePhase = new List<Match>()
                    };
                    league1.PhasesInLeague.Add(phase);
                }


                string[] teamNames = { "KRC Genk", "Union", "Antwerp", "Club Brugge", "AA Gent",
                    "Standard Liège", "Westerlo", "Cercle Brugge", "Charleroi", "OH Leuven", "Anderlecht",
                    "STVV", "KV Mechelen", "KV Kortrijk", "KAS Eupen", "KV Oostende",
                    "Zulte Waregem", "RFC Seraing" };

                var regularPhase = league1.PhasesInLeague.FirstOrDefault(phase => phase.LeaguePhaseName == "Sezon Zasadniczy");

                if (regularPhase != null)
                {
                    foreach (var teamName in teamNames)
                    {
                        var team = new Team()
                        {
                            TeamName = teamName,
                            LeaguePhaseId = regularPhase.LeaguePhaseId
                        };
                        regularPhase.TeamsInLeaguePhase.Add(team);
                    }

                    // Tablica par drużyn i wyników
                    var matchesData = new (string FirstTeamName, string SecondTeamName, int FirstTeamGoals, int SecondTeamGoals)[]
                    {
                        ("Standard Liège", "AA Gent", 2, 2),
                        ("Charleroi", "KAS Eupen", 3, 1 ),
                        ("KV Kortrijk", "OH Leuven", 0, 2),
                        ("Zulte Waregem", "RFC Seraing", 2, 0),
                        ("STVV", "Union", 1, 1),
                        ("Club Brugge", "AA Gent", 3, 2),
                        ("KV Mechelen", "Antwerp", 0, 2),
                        ("Anderlecht", "KV Oostende", 2, 0),
                        ("Westerlo", "Cercle Brugge", 2, 0)
                    };

                    // Dodawanie meczów do fazy ligowej
                    foreach (var matchData in matchesData)
                    {
                        var firstTeam = regularPhase.TeamsInLeaguePhase.Single(team => team.TeamName == matchData.FirstTeamName);
                        var secondTeam = regularPhase.TeamsInLeaguePhase.Single(team => team.TeamName == matchData.SecondTeamName);

                        regularPhase.MatchesInLeaguePhase.Add(new Match
                        {
                            FirstTeam = firstTeam,
                            SecondTeam = secondTeam,
                            FirstTeamGoals = matchData.FirstTeamGoals,
                            SecondTeamGoals = matchData.SecondTeamGoals
                        });
                    }
                }

                _context.Leagues.Add(league1);
                await _context.SaveChangesAsync();
                //}
            }
        }
    }
}