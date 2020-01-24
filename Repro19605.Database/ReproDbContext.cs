using System;
using Microsoft.EntityFrameworkCore;
using Repro19605.Entities;

namespace Repro19605.Database
{
    public class ReproDbContext : DbContext
    {
        public virtual DbSet<Widget> Widgets { get; set; }

        public ReproDbContext(DbContextOptions<ReproDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Widget>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();

                entity.Property(e => e.Price).IsRequired().HasColumnType("smallmoney");
            });
        }
    }
}
