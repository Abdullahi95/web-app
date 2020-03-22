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
        public DbSet<League> League { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Team> Teams { get; set; }

        
        
        // finds database and if none exists it creates one.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=FootballDb;");
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // relationship between player and team
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamID);


            // relationship between player and stat
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Stat)
                .WithMany(s => s.Players)
                .HasForeignKey(p => p.StatID);

            // relationship between team and league
            modelBuilder.Entity<Team>()
                .HasOne(t => t.League)
                .WithMany(l => l.Teams)
                .HasForeignKey(t => t.LeagueID);

            modelBuilder.Entity<League>()
                .HasMany(l => l.Teams)
                .WithOne(t => t.League);
                
              



            modelBuilder.Entity<Player>().HasData(

                new Player()
                {
                    PlayerID = 1,
                    StatID = 1,
                    PlayerName = "Hassan A",
                    TeamID = (int)ETeam.Tekk_Republic,
                    Age = 24,
                    Foot = 'R',
                    Pos = 'M',
                    ShirtNum = 6
                },

                new Player()
                {
                    PlayerID = 2,
                    StatID = 2,
                    PlayerName = "Mohammed H",
                    TeamID = (int)ETeam.L_Hermanos,
                    Age = 25,
                    Foot = 'R',
                    Pos = 'F',
                    ShirtNum = 9

                }

                );



            modelBuilder.Entity<Stat>().HasData(
                new Stat() { StatID = 1, Goals = 4, Assists = 6, Apps = 7, Red = 0, Yel = 0, TContributions = 10 },
                new Stat() { StatID = 2, Goals = 3, Assists = 2, Apps = 10, Yel = 1, Red = 0, TContributions = 5}
                );


                modelBuilder.Entity<Team>().HasData(
                new Team() { LeagueID = (int)ETeam.Tekk_Republic, TeamID = (int)ETeam.Tekk_Republic, TName = "Tekk Republic", TCaptain = "Tariq"},
                new Team() { LeagueID = (int)ETeam.L_Hermanos, TeamID = (int)ETeam.L_Hermanos, TName = "Locos Hermanos", TCaptain = "Mohammed H"},
                new Team() { LeagueID = (int)ETeam.Akdem, TCaptain = "//", TeamID = (int)ETeam.Akdem, TName = "Akdem"},
                new Team() { LeagueID = (int)ETeam.Eagles_United, TCaptain = "//", TeamID = (int)ETeam.Eagles_United, TName = "Eagles United"},
                new Team() { LeagueID = (int)ETeam.Hurli_FC, TCaptain = "Keyton", TeamID = (int)ETeam.Hurli_FC, TName = "Hurli FC"},
                new Team() { LeagueID = (int)ETeam.AR_FC, TCaptain = "Zak Y", TeamID = (int)ETeam.AR_FC, TName = "AR FC"}
                );


            modelBuilder.Entity<League>().HasData(
                new League() { LTeam = "Tekk Republic", LeagueID = (int)ETeam.Tekk_Republic, W = 9, D = 1, L = 0, MP = 10, GA = 52, GF = 16, GD = 38, PTS = 28 },
                new League() { LTeam = "L.Hermanos" ,LeagueID = (int)ETeam.L_Hermanos, W = 1, D = 1, L = 8, GA = 67, GF = 22, GD = -45, MP = 10, PTS = 4 },
                new League() { LTeam = "AR FC", LeagueID = (int)ETeam.AR_FC, W = 7, D = 0, L = 3, GA = 33, GF = 52, GD = 19, MP = 10, PTS = 21 },
                new League() { LTeam = "Eagles United", LeagueID = (int)ETeam.Eagles_United, W = 3, D = 0, L = 7, GA = 64, GF = 32, GD = -32, MP = 10, PTS = 9 },
                new League() { LTeam = "Hurli FC", LeagueID = (int)ETeam.Hurli_FC, W = 4, D = 1, L = 5, GA = 39, GF = 44, GD = 5, MP = 10, PTS = 13 },
                new League() { LTeam = "Akdem FC", LeagueID = (int)ETeam.Akdem, W = 4, D = 1, L = 5, GA = 30, GF = 45, GD = 15, MP = 10, PTS = 13}                
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
