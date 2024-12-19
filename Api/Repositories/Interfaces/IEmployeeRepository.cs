using Api.Models.Entities;

namespace Api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Guid> AddAsync(Employee employee);
        Task<Employee> GetByUserAsync(Guid userId);
        Task<List<Employee>> GetEmployees();
    }
}
