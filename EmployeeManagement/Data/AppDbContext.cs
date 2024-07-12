using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class AppDbContext :  IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Departments
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Human Resources",
                    Address = "Floor 2, Building A",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-100),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 2,
                    Name = "Information Technology",
                    Address = "Floor 3, Building B",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-95),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 3,
                    Name = "Finance",
                    Address = "Floor 4, Building A",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-90),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 4,
                    Name = "Marketing",
                    Address = "Floor 1, Building C",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-85),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 5,
                    Name = "Sales",
                    Address = "Floor 2, Building C",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-80),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 6,
                    Name = "Research and Development",
                    Address = "Floor 5, Building B",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-75),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 7,
                    Name = "Customer Service",
                    Address = "Floor 1, Building A",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-70),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 8,
                    Name = "Legal",
                    Address = "Floor 6, Building A",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-65),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 9,
                    Name = "Production",
                    Address = "Floor 1, Building D",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-60),
                    CreatedBy = 1
                },
                new Department
                {
                    Id = 10,
                    Name = "Quality Assurance",
                    Address = "Floor 2, Building D",
                    Status = true,
                    CreatedDate = DateTime.Now.AddDays(-55),
                    CreatedBy = 1
                }
            );
        }
    }
}
