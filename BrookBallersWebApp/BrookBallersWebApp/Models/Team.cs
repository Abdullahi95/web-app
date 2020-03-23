using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
        public int MP { get; set; }
        public int W { get; set; }
        public int D { get; set; }
        public int L { get; set; }
        public int GF { get; set; }
        public int GA { get; set; }
        public int GD { get; set; }
        public int PTS { get; set; }

        public ICollection<Player> Players { get; set; }
        
    }
}
