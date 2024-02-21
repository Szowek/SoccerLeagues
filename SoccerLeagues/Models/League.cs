using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public List<Team> TeamsInLeague { get; set; }        
        public List<Match> MatchesInleague { get; set; }

    }
}
