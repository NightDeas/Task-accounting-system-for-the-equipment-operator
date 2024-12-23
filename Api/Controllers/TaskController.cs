using System.IdentityModel.Tokens.Jwt;
using Api.Models.Entities;
using Api.Models.Requests;
using Api.Models.Requests.Params;
using Api.Services.Intefraces;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public TaskController(ITaskService taskService, IUserService userService, IEmployeeService employeeService, IMapper mapper, UserManager<User> userManager)
        {
            _taskService = taskService;
            _userService = userService;
            _employeeService = employeeService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery]TaskQueryParams @params)
        {
            var tasks = await _taskService.GetAllAsync(@params);
            return Ok(tasks);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("currentEmployee")]
        public async Task<IActionResult> GetAllForEmployee([FromQuery]TaskQueryParams @params)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("Не авторизован");
            var employeeId = (await _employeeService.GetByUser(user.Id)).Id;
            var tasks = await _taskService.GetAllByEmployee(employeeId, @params);
            return Ok(tasks);
        }

        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(TaskCreateRequest task)
        {
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //    return Unauthorized();
            //var role = await _userManager.GetRolesAsync(user);
            //if (!role.Contains("ADMINISTRATOR"))
            //    return Forbid();
            //
            var id = await _taskService.AddAsync(task);
            return Ok(id);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> UpdateTask(Guid taskId, TaskRequest updateTask)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();
            var role = await _userManager.GetRolesAsync(user);
            if (!role.Contains("ADMINISTRATOR"))
                return Forbid();
            var task = await _taskService.Get(taskId);
            if (task == null)
                return NotFound("taskId notFound");
            var taskResult = await _taskService.UpdateAsync(taskId, updateTask);
            return Ok(taskResult);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("taskCompleted")]
        public async Task<IActionResult> TaskCompleted(UpdateTaskCompleted request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var task = await _taskService.Get(request.TaskId);
            if (task == null)
                return NotFound("taskId notFound");
          
            task.IsCompleted = request.IsCompleted;
            var taskRequest = _mapper.Map<TaskRequest>(task);
            var taskResult = await _taskService.UpdateAsync(request.TaskId, taskRequest);
            return Ok(taskResult);
        }
    }
}
