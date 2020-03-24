using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrookBallersWebApp.Models
{
    public class FootballDbContext : DbContext
    {

        public FootballDbContext()
        {

        }   
        

        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options) { }


        //tables
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        
        // finds database and if none exists it creates one.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=FootballDb;");
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamID);

            modelBuilder.Entity<Player>()
                .HasKey(p => p.PlayerID);

            modelBuilder.Entity<Team>()
                .HasKey(t => t.TeamID);

            
            modelBuilder.Entity<Player>().HasData(

                new Player()
                {
                    PlayerID = 1,
                    PlayerName = "Hassan A",
                    TeamID = (int)ETeam.Tekk_Republic,
                    Age = 24,
                    Foot = 'R',
                    Pos = 'M',
                    Goals = 4,
                    Assists = 6,
                    Apps = 7,
                    Red = 0,
                    Yel = 0,
                    TGA = 10
                },

                new Player()
                {
                    PlayerID = 2,
                    PlayerName = "Mohammed H",
                    TeamID = (int)ETeam.L_Hermanos,
                    Age = 25,
                    Foot = 'R',
                    Pos = 'F',
                    Goals = 3,
                    Assists = 2,
                    Apps = 10,
                    Yel = 4,
                    Red = 0,
                    TGA = 5
                });



            modelBuilder.Entity<Team>().HasData(
                new Team() { TeamName = "Tekk Republic", W = 9, D = 1, L = 0, MP = 10, GA = 52, GF = 16, GD = 38, PTS = 28, TeamID = (int)ETeam.Tekk_Republic},
                new Team() { TeamName = "L.Hermanos", W = 1, D = 1, L = 8, GA = 67, GF = 22, GD = -45, MP = 10, PTS = 4, TeamID = (int)ETeam.L_Hermanos },
                new Team() { TeamName = "AR FC", W = 7, D = 0, L = 3, GA = 33, GF = 52, GD = 19, MP = 10, PTS = 21, TeamID = (int)ETeam.AR_FC },
                new Team() { TeamName = "Eagles United", W = 3, D = 0, L = 7, GA = 64, GF = 32, GD = -32, MP = 10, PTS = 9, TeamID = (int)ETeam.Eagles_United},
                new Team() { TeamName = "Hurli FC", W = 4, D = 1, L = 5, GA = 39, GF = 44, GD = 5, MP = 10, PTS = 13, TeamID = (int)ETeam.Hurli_FC },
                new Team() { TeamName = "Akdem FC",  W = 4, D = 1, L = 5, GA = 30, GF = 45, GD = 15, MP = 10, PTS = 13, TeamID = (int)ETeam.Akdem }                
                ); 
        }




        enum ETeam
        {
            Tekk_Republic = 1,
            AR_FC,
            Hurli_FC,
            Akdem,
            Eagles_United,
            L_Hermanos,
        }

        

    }
}
