using Api.Models.Requests;
using Api.Models.Requests.Params;
using Api.Models.Responses;
using Api.Repositories.Interfaces;
using Api.Services.Intefraces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(TaskCreateRequest task)
        {
            var entityTask = _mapper.Map<Models.Entities.Task>(task);
            var id = await _taskRepository.AddAsync(entityTask);
            return id;
        }

        public async Task<TaskResponse> Get(Guid taskId)
        {
            var task = await _taskRepository.GetAsync(taskId);
            var taskResponse = _mapper.Map<TaskResponse>(task);
            return taskResponse;
        }

        public async Task<List<TaskResponse>> GetAllAsync(TaskQueryParams @params)
        {
            var entitiesTask = await _taskRepository.GetAllAsync(@params);
            List<TaskResponse> tasks = new();
            foreach (var task in entitiesTask)
            {
                tasks.Add(_mapper.Map<TaskResponse>(task));
            }
            return tasks;
        }

        public async Task<List<TaskResponse>> GetAllByEmployee(Guid employeeId, TaskQueryParams @params)
        {
            var entitiesTask = await _taskRepository.GetAllByEmployeeAsync(employeeId, @params);
            List<TaskResponse> tasks = new();
            foreach (var task in entitiesTask)
            {
                tasks.Add(_mapper.Map<TaskResponse>(task));
            }
            return tasks;
        }

        public async Task Remove(Guid taskId)
        {
            await _taskRepository.Remove(taskId);
        }

        public async Task<TaskResponse> UpdateAsync(Guid taskId, TaskRequest updateTask)
        {
            var entitiyUpdateTask = _mapper.Map<Models.Entities.Task>(updateTask);
            var result = await _taskRepository.UpdateAsync(taskId, entitiyUpdateTask);
            var resultResponse = _mapper.Map<TaskResponse>(result);
            return resultResponse;
        }
    }
}
