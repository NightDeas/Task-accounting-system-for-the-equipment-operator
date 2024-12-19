using Api.Models.Requests;
using Api.Models.Requests.Params;
using Api.Models.Responses;

namespace Api.Services.Intefraces
{
    public interface ITaskService
    {
        Task<List<TaskResponse>> GetAllAsync(TaskQueryParams @params);
        Task<List<TaskResponse>> GetAllByEmployee(Guid employeeId, TaskQueryParams @params);
        Task<Guid> AddAsync(TaskCreateRequest task);
        Task<TaskResponse> UpdateAsync(Guid taskId, TaskRequest updateTask);
        Task Remove(Guid taskId);
        Task<TaskResponse> Get(Guid taskId);
    }
}
