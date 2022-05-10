using DotNetWebAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { 

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Department Table
            modelBuilder.Entity<Department>().HasData(
                 new Department { DepartmentId = 1, DepartmentName= "IT"});
            modelBuilder.Entity<Department>().HasData(
                 new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                 new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                 new Department { DepartmentId = 4, DepartmentName = "Admin" });

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
               EmployeeId = 1,
               FirstName = "Sun",
               LastName =   "Khan",
               Email =  "sun@gmail.com",
               DateOfBirth = new DateTime(1978, 12,11),
               Gender = Gender.Male,
               DepartmentId = 1,
               PhotoPath =  "images/sam.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "uha",
                LastName = "Khan",
                Email = "uha@gmail.com",
                DateOfBirth = new DateTime(1968, 12, 11),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/uha.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "hana",
                LastName = "aadf",
                Email = "han@gmail.com",
                DateOfBirth = new DateTime(1969, 12, 11),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/hana.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Khan",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1978, 12, 11),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/sara.jpg"
            });

        }
    }
}
