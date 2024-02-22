using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.ModelsEntities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }
        public int LeagueId { get; set; }
    }
}
