using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class Stat
    {
        [Key]
        public int StatID { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int TContributions { get; set; }
        public int Apps { get; set; }
        public int Yel { get; set; }
        public int Red { get; set; }


        // stat model has many players
        public ICollection<Player> Players { get; set; }



    }
}
