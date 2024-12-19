using Api.Services.Intefraces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public EmployeeController(IEmployeeService employeeService, IUserService userService)
        {
            _employeeService = employeeService;
            _userService = userService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> Get()
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var employee = await _employeeService.GetByUser(user.Result.Id);
            return Ok(employee);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _employeeService.GetEmployees();
            return Ok(result);
        }
    }
}
