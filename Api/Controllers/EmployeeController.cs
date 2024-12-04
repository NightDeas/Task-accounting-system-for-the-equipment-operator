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
            var user = await _userService.GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var employee = await _employeeService.GetByUserAsync(user.Id);
            return Ok(employee);
        }
    }
}
