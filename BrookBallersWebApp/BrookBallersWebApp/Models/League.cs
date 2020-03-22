using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class League
    {
        [Key]
        public int LeagueID { get; set; }
        [Display(Name = "Team")]
        public string LTeam { get; set; }

        [MaxLength(10)]
        [MinLength(0)]
        public int MP { get; set; }

        [MaxLength(10)]
        [MinLength(0)]
        public int W { get; set; }

        [MaxLength(10)]
        [MinLength(0)]
        public int D { get; set; }

        [MaxLength(10)]
        [MinLength(0)]
        public int L { get; set; }
        public int GF { get; set; }
        public int GA { get; set; }
        public int GD { get; set; }

        [MinLength(0)]
        [MaxLength(30)]
        public int PTS { get; set; }

        //League has many teams.
        public ICollection<Team> Teams { get; set; }

   



    }
}
