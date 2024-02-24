using SoccerLeagues.Entities.ModelsEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        //[ForeignKey("LeagueId")]
        //public League League { get; set; }
        //public int LeagueId { get; set;}

        [ForeignKey("LeaguePhaseId")]
        public LeaguePhase LeaguePhase { get; set; }
        public int LeaguePhaseId { get; set; }
    }
}
