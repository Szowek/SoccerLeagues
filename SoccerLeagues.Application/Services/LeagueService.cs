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
}
