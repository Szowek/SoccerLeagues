﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerLeagues.Database;

#nullable disable

namespace SoccerLeagues.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240224180305_firstUpdate")]
    partial class firstUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LeagueName")
                        .HasColumnType("TEXT");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.LeaguePhase", b =>
                {
                    b.Property<int>("LeaguePhaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LeaguePhaseName")
                        .HasColumnType("TEXT");

                    b.HasKey("LeaguePhaseId");

                    b.HasIndex("LeagueId");

                    b.ToTable("LeaguePhases");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FirstTeamGoals")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FirstTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeaguePhaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecondTeamGoals")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecondTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatchId");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("LeaguePhaseId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeaguePhaseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("LeaguePhaseId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.TeamStatisticsViewModel", b =>
                {
                    b.Property<int>("Draws")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoalsConceded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastResults")
                        .HasColumnType("TEXT");

                    b.Property<string>("LeagueName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Losses")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhaseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Wins")
                        .HasColumnType("INTEGER");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.LeaguePhase", b =>
                {
                    b.HasOne("SoccerLeagues.Entities.ModelsEntities.League", "League")
                        .WithMany("PhasesInLeague")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.Match", b =>
                {
                    b.HasOne("SoccerLeagues.Entities.ModelsEntities.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerLeagues.Entities.ModelsEntities.LeaguePhase", "LeaguePhase")
                        .WithMany("MatchesInLeaguePhase")
                        .HasForeignKey("LeaguePhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerLeagues.Entities.ModelsEntities.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstTeam");

                    b.Navigation("LeaguePhase");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.Team", b =>
                {
                    b.HasOne("SoccerLeagues.Entities.ModelsEntities.LeaguePhase", "LeaguePhase")
                        .WithMany("TeamsInLeaguePhase")
                        .HasForeignKey("LeaguePhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaguePhase");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.League", b =>
                {
                    b.Navigation("PhasesInLeague");
                });

            modelBuilder.Entity("SoccerLeagues.Entities.ModelsEntities.LeaguePhase", b =>
                {
                    b.Navigation("MatchesInLeaguePhase");

                    b.Navigation("TeamsInLeaguePhase");
                });
#pragma warning restore 612, 618
        }
    }
}
