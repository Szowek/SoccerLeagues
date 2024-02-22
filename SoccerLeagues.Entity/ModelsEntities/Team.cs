using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.ModelsEntities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        [ForeignKey("LeagueId")]
        public League Leagues { get; set; }
        public int LeagueId { get; set;}
    }
}
