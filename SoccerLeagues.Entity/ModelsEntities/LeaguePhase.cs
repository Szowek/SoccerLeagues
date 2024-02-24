using SoccerLeagues.Entities.ModelsEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class LeaguePhase
    {
        public int LeaguePhaseId { get; set; }
        public string? LeaguePhaseName { get; set; }
        public List<Team>? TeamsInLeaguePhase { get; set; }
        public List<Match>? MatchesInLeaguePhase { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }
        public int LeagueId { get; set; }
    }
}
