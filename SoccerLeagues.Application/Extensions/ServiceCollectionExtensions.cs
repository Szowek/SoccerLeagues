using Microsoft.Extensions.DependencyInjection;
using SoccerLeagues.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagues.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services) {
            services.AddScoped<ILeagueService, LeagueService>();
        }
    }
}
