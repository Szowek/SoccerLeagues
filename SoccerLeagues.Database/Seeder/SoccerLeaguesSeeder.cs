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
                if (!_context.Leagues.Any())
                    {
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

                    string[] teamNames = { "Genk", "Union Saint-Gilloise", "Antwerp", "Club Brugge", "Gent",
                        "Standard Liège", "Westerlo", "Cercle Brugge", "Charleroi", "OHL", "Anderlecht",
                        "STVV", "Mechelen", "Kortrijk", "Eupen", "Oostende",
                        "Zulte-Waregem", "Seraing United" };

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

                        var matchesData = new (string FirstTeamName, string SecondTeamName, int FirstTeamGoals, int SecondTeamGoals)[]
                        {
                            ("Standard Liège", "Gent", 2, 2),
                            ("Charleroi", "Eupen", 3, 1 ),
                            ("Kortrijk", "OHL", 0, 2),
                            ("Zulte-Waregem", "Seraing United", 2, 0),
                            ("STVV", "Union Saint-Gilloise", 1, 1),
                            ("Club Brugge", "Genk", 3, 2),
                            ("Mechelen", "Antwerp", 0, 2),
                            ("Anderlecht", "Oostende", 2, 0),
                            ("Westerlo", "Cercle Brugge", 2, 0),
                            ("Union Saint-Gilloise", "Charleroi", 1, 0),
                            ("Cercle Brugge", "Anderlecht", 1, 0 ),
                            ("OHL", "Westerlo", 2, 0),
                            ("Oostende", "Mechelen", 2, 1),
                            ("Gent", "STVV", 1, 1),
                            ("Genk", "Standard Liège", 3, 1),
                            ("Eupen", "Club Brugge", 2, 1),
                            ("Seraing United", "Kortrijk", 0, 1),
                            ("Antwerp", "Zulte-Waregem", 1, 0)
                        };

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
                }
            }
        }
    }
}