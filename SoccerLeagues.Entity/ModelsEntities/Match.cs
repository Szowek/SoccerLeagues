using SoccerLeagues.Entities.ModelsEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public int FirstTeamGoals { get; set; }
        public int SecondTeamGoals { get; set; }

        [ForeignKey("LeaguePhaseId")]
        public LeaguePhase LeaguePhase { get; set; }
        public int LeaguePhaseId { get; set; }

        [ForeignKey("FirstTeamId")]
        public Team FirstTeam { get; set; }
        [ForeignKey("SecondTeamId")]
        public Team SecondTeam { get; set; }
    }
}
