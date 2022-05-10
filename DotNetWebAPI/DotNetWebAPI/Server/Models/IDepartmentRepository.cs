using DotNetWebAPI.Shared;

namespace DotNetWebAPI.Server.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int departmentId);
    }
}
