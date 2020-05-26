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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
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

            #endregion

            #region Individual property constraints.

            modelBuilder.Entity<Person>()
                .HasIndex(e => e.Email)
                .IsUnique();

            #endregion
        }
    }
}
