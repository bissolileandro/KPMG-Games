using KPMG.Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Games.Infra.Data.Contexto
{
    public class KPGMGamesContext : DbContext
    {


        public KPGMGamesContext(string connectionString) 
            : base(GetOptions(connectionString))
        {

        }
        public KPGMGamesContext(DbContextOptions<KPGMGamesContext> options)
            :base(options)
        {

        }

        DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameResult>()
                .HasKey(x => new { x.Id });
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
