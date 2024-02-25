using Microsoft.EntityFrameworkCore;
using SoccerLeagues.Entities.ModelsEntities;

namespace SoccerLeagues.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }

        public DbSet<League> Leagues { get; set; }
        public DbSet<LeaguePhase> LeaguePhases { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStatisticsViewModel> TeamStatisticsViewModels { get; set; }
        public DbSet<FavoriteTeam> FavoriteTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamStatisticsViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });

            modelBuilder.Entity<League>()
                .HasMany(l => l.PhasesInLeague)
                .WithOne(p => p.League)
                .HasForeignKey(p => p.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);            
            
            modelBuilder.Entity<LeaguePhase>()
                .HasMany(lp => lp.TeamsInLeaguePhase)
                .WithOne(t => t.LeaguePhase)
                .HasForeignKey(t => t.LeaguePhaseId)
                .OnDelete(DeleteBehavior.Cascade);            
            
            modelBuilder.Entity<LeaguePhase>()
                .HasMany(lp => lp.MatchesInLeaguePhase)
                .WithOne(m => m.LeaguePhase)
                .HasForeignKey(m => m.LeaguePhaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
