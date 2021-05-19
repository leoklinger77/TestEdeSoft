using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.ManyToMany;

namespace Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }

        public DbSet<Caes> Caes { get; set; }
        public DbSet<Donos> Donos { get; set; }
        public DbSet<CaesDono> CaesDono { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaesDono>()
                .HasKey(x => new { x.DonosId, x.CaesId });
            modelBuilder.Entity<CaesDono>()
                .HasOne(x => x.Donos)
                .WithMany(x => x.CaesDono)
                .HasForeignKey(x => x.DonosId);
            modelBuilder.Entity<CaesDono>()
                .HasOne(x => x.Caes)
                .WithMany(x => x.CaesDono)
                .HasForeignKey(x => x.CaesId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
