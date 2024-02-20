using SoccerLeagues.Seeder;

namespace SoccerLeagues.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void StartSeeder(this IServiceCollection services)
        {
            services.AddScoped<SoccerLeaguesSeeder>();
        }
    }
}
