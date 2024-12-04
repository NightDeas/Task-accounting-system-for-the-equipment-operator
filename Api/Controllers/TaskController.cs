using Api.Models.Requests;
using Api.Services.Intefraces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public TaskController(ITaskService taskService, IUserService userService, IEmployeeService employeeService)
        {
            _taskService = taskService;
            _userService = userService;
            _employeeService = employeeService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("currentEmployee")]
        public async Task<IActionResult> GetAllForEmployee()
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var tasks = await _taskService.GetAllByEmployee(user.Id);
            return Ok(tasks);
        }

        [HttpPost]
        [Authorize("Administrator")]
        public async Task<IActionResult> Post(TaskCreateRequest task)
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var id = await _taskService.AddAsync(task);
            return Ok(id);
        }


        [HttpPut]
        [Authorize("Administrator")]
        public async Task<IActionResult> UpdateTask(Guid taskId, TaskRequest updateTask)
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var taskResult = await _taskService.UpdateAsync(taskId, updateTask);
            return Ok(taskResult);
        }

        [HttpPut("{taskId}/taskCompleted/{isCompleted}")]
        public async Task<IActionResult> TaskCompleted(Guid taskId, bool isCompleted)
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var task = await _taskService.Get(taskId);
            if (task == null)
                return NotFound();
            task.IsCompleted = isCompleted;
            var taskRequest = _mapper.Map<TaskRequest>(task);
            var taskResult = await _taskService.UpdateAsync(taskId, taskRequest);
            return Ok(taskResult);
        }




    }
}
