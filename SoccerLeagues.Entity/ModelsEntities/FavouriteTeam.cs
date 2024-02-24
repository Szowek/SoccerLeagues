using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerLeagues.Entities.ModelsEntities;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class FavoriteTeam
    {
        [Key]
        public int FavoriteTeamId { get; set; }

        public string UserId { get; set; }

        public string TeamId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}