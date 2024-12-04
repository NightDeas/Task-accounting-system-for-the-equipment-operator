using Api.Models.Requests;
using Api.Models.Responses;

namespace Api.Services.Intefraces
{
    public interface ITaskService
    {
        Task<List<TaskResponse>> GetAllAsync();
        Task<List<TaskResponse>> GetAllByEmployee(Guid employeeId);
        Task<Guid> AddAsync(TaskCreateRequest task);
        Task<TaskResponse> UpdateAsync(Guid taskId, TaskRequest updateTask);
        Task Remove(Guid taskId);
        Task<TaskResponse> Get(Guid taskId);
    }
}
