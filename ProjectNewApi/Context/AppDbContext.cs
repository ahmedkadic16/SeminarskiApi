using Microsoft.EntityFrameworkCore;
using ProjectNewApi.Models;

namespace ProjectNewApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Studio>().ToTable("studios");
            modelBuilder.Entity<Lokacija>().ToTable("lokacije");
        }
    }
}
