using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        [Display(Name = "Name")]
        public string PlayerName { get; set; }
        public int Age { get; set; }
        public char Pos { get; set; }
        public char Foot { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        [Display(Name = "G + A")]
        public int TGA { get; set; }
        public int Apps { get; set; }
        public int Yel { get; set; }
        public int Red { get; set; }

        // Foreign Key
        public int? TeamID { get; set; }
        public Team Team { get; set; }
        



    }
}
