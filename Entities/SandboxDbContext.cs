using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class SandboxDbContext : DbContext
    {
        public SandboxDbContext(DbContextOptions<SandboxDbContext> dbContextOptions)
           : base(dbContextOptions) { }

        public SandboxDbContext() { }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SandboxDbContext;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Indices.

            modelBuilder.Entity<Person>()
                .HasIndex(e => e.Email);
            modelBuilder.Entity<Person>()
                .HasIndex(e => e.FirstName);
            modelBuilder.Entity<Person>()
                .HasIndex(e => e.LastName);

            modelBuilder.Entity<Product>()
                .HasIndex(e => e.Name);
            modelBuilder.Entity<Product>()
                .HasIndex(e => e.Code);

            #endregion

            #region Individual property constraints.

            modelBuilder.Entity<Person>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(e => e.Code)
                .IsUnique();

            #endregion
        }
    }
}
