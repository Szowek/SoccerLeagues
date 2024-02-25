using SoccerLeagues.Entities.ModelsEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        [ForeignKey("LeaguePhaseId")]
        public LeaguePhase LeaguePhase { get; set; }
        public int LeaguePhaseId { get; set; }
    }
}
