using System;
using LottoWForms.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWForms
{
    public class DBManager: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; } 
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Balance> Balances { get; set; }

        public string DbPath { get; }
        
        public DBManager()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "lottowpf.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<Balance>()
                .HasIndex(b => b.UserId)
                .IsUnique();
        }
    }
}