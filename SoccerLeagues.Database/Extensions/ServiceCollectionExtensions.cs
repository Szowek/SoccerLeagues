using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoccerLeagues.Entities.ModelsEntities;
using SoccerLeagues.MVC.Areas.Identity.Data;
using SoccerLeagues.Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagues.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite($"DataSource=SoccerLeagueDb.db"));
            services.AddDbContext<AuthDbContext>(options => options.UseSqlite($"DataSource=IdentityDb.db"));
            services.AddScoped<SoccerLeaguesSeeder>();
            services.AddScoped<ILeagueLog, LeagueLog>();
        }        
    }
}
