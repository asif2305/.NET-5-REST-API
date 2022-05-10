using DotNetWebAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await appDbContext.Departments
                        .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
           return await appDbContext.Departments.ToListAsync();
        }
    }
 }
