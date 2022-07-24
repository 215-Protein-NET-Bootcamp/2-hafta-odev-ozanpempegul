using DatabaseHomework.Models;

namespace DatabaseHomework.Repository
{
    public interface IDepartmentRepository
    {        
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task SaveDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
    }
}
