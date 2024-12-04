using Api.Models.DTO;
using Api.Models.Entities;
using Api.Models.Requests;

namespace Api.Services.Intefraces
{
    public interface IEmployeeService
    {
        Task<Guid> Add(EmployeeRequest employeeRequest);
        Task<EmployeeDTO> GetByUser(Guid userId);
    }
}
