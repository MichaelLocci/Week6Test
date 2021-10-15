using AcademyG.Week6Test.Core.EF.Configuration;
using AcademyG.Week6Test.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcademyG.Week6Test.Core.EF
{
    public class ManagementContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #region COSTRUTTORI

        public ManagementContext() :base() { }
        public ManagementContext(DbContextOptions<ManagementContext> options) : base() { }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Management;Trusted_Connection=True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
