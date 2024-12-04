using Api.Models.Responses;
namespace Api.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Models.Entities.Task>> GetAllAsync();
        Task<List<Models.Entities.Task>> GetAllByEmployeeAsync(Guid employeeId);
        Task<Guid> AddAsync(Models.Entities.Task task);
        Task<Models.Entities.Task> UpdateAsync(Guid taskId, Models.Entities.Task updateTask);
        Task Remove(Guid taskId);
        Task<Models.Entities.Task> GetAsync(Guid taskId);

    }
}
