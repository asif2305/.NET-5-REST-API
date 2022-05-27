using GrpcServicegWithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcServicegWithEF.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(GetStudent());
        }

        public DbSet<Student> Students { get; set; }
        private static List<Student> GetStudent()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){ StudentId = 1, FirstName = "Ali", LastName = "khan", School="Nursing"},
                new Student(){ StudentId = 2, FirstName = "khasd", LastName = "tzhr", School="Mining"},
                new Student(){ StudentId = 3, FirstName = "Hosna", LastName = "Ahmed", School="Doctoer"},
                new Student(){ StudentId = 4, FirstName = "Rhana", LastName = "Bosra", School="University"},
                new Student(){ StudentId = 5, FirstName = "Momin", LastName = "HOssain", School="Bachelor"},
            };
            return students;
        }
    }
}
