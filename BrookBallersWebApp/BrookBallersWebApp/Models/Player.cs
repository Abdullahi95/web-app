using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Display(Name = "Name")]
        public string PlayerName { get; set; }
        public int Age { get; set; }
        public char Pos { get; set; }
        public char Foot { get; set; }
        [Display(Name = "Shirt Num")]
        public int ShirtNum { get; set; }

        // A player has a one set of stats
        public Stat Stat { get; set; }
        public int? StatID { get; set; }


        // A player has one team
        public Team Team { get; set; }
        public int? TeamID { get; set; }



    }
}
