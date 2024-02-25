using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagues.Entities.ModelsEntities
{
    public class FavoriteTeam
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
