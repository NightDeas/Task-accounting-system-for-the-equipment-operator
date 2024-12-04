using Api.Models.DTO;
using Api.Models.Entities;
using Api.Models.Requests;
using Api.Repositories.Interfaces;
using Api.Services.Intefraces;
using AutoMapper;

namespace Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Add(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.Map<Employee>(employeeRequest);
            var result = await _employeeRepository.AddAsync(employee);
            return result;
        }

        public async Task<EmployeeDTO> GetByUserAsync(Guid userId)
        {
            var employee = await _employeeRepository.GetByUserAsync(userId);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }
    }
}
