using Api.Models.Entities;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<Employee> GetByUserAsync(Guid userId)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }
    }
}
