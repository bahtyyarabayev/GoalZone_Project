using GoalZonePremierLig.Web.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GoalZonePremierLig.Web.Api.Context
{
    public class GoalZoneContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TKHFJ4C\\MSSQLSERVER01;initial Catalog=GoalZoneDb;integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Standing> Standings { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<MatchEvents> MatchEvents { get; set; }
        public DbSet<Statistics> Statistics { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fixture>()
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeMatches)
                .HasForeignKey(x => x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fixture>()
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayMatches)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
 
}
