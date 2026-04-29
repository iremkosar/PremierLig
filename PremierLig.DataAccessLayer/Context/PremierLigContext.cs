using Microsoft.EntityFrameworkCore;
using PremierLig.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.DataAccessLayer.Context
{
    public class PremierLigContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGIR0F4\\SQLEXPRESS;initial Catalog=ApiDbPremier;integrated Security=true");
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<MatchStatistic> MatchStatistics { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fixture>()
                .HasOne<Team>()
                .WithMany()
                .HasForeignKey(f => f.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fixture>()
                .HasOne<Team>()
                .WithMany()
                .HasForeignKey(f => f.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
