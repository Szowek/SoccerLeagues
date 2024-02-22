using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Database;
using SoccerLeagues.ModelsEntities;

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

                var league1 = new League()
                {
                    LeagueName = "Test5",
                };
                _context.Leagues.Add(league1);
                await _context.SaveChangesAsync();
                //}
            }
        }
    }
}