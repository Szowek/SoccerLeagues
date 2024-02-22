using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerLeagues.ModelsEntities
{
    public interface ILeagueLog
    {
        Task CreateLog(ModelsEntities.League log);
        Task<IEnumerable<ModelsEntities.League>> GetAll();
    }
    public class League
    {
        public int LeagueId { get; set; }
        public string ?LeagueName { get; set; }
        public List<Team> ?TeamsInLeague { get; set; }        
        public List<Match> ?MatchesInleague { get; set; }

    }
}
