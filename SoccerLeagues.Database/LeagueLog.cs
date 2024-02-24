using SoccerLeagues.Entities.ModelsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoccerLeagues.Database
{
    public class LeagueLog : ILeagueLog
    {
        private readonly ApplicationDbContext _context;
        public LeagueLog(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateLog(League log)
        {
            _context.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<League>> GetAll() => await _context.Leagues.ToListAsync();
    }
}
