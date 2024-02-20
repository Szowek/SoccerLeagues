using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Models;

namespace SoccerLeagues.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<League>()
                .HasMany(l => l.TeamsInLeague)
                .WithOne(t => t.Leagues)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<League>()
                .HasMany(l => l.MatchesInleague)
                .WithOne(m => m.League)
                .HasForeignKey(m => m.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
