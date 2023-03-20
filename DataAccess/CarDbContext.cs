using DataAccess.Configurations;
using DataAccess.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataAccess
{
    public class CarDbContext : IdentityDbContext
    {
        
        public CarDbContext() : base() { }

        public CarDbContext(DbContextOptions options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedCars();

            //DbContextExtensions.SeedCategories(modelBuilder);
            //DbContextExtensions.SeedCars(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connStr);
        }

        /* ----------------- Data Collections -----------------*/
        public DbSet<Car> Cars { get; set; }
    }

}