using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TName { get; set; }
        public string TCaptain { get; set; }
     
        public int? LeagueID { get; set; }
        public League League { get; set; }

        public ICollection<Player> Players { get; set; }

    }
}
