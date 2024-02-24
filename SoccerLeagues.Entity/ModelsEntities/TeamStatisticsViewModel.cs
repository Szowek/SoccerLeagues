using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class TeamStatisticsViewModel
    {
        public string LeagueName { get; set; }
        public int Position { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public string ?LastResults { get; set; }
        public int Points { get; set; }
        public string PhaseName { get; set; }
    }
}
