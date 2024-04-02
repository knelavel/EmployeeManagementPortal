

using System.Collections.Generic;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePhone> EmployeePhones { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeePhones)
                .WithOne(e => e.Employee)
                .HasForeignKey(p => p.EmployeeId);


            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeAddresss)
                .WithOne(e => e.Employee)
                .HasForeignKey(p => p.EmployeeId);


        }

    }

}
