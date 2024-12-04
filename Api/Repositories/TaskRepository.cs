using Api.Models.Entities;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;

        public TaskRepository(Context context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Models.Entities.Task task)
        {
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;

        }

        public async Task<Models.Entities.Task> GetAsync(Guid taskId)
        {
            var task = await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == taskId);
            return task;
        }

        public async Task<List<Models.Entities.Task>> GetAllAsync()
        {
            return await _context.Tasks
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Models.Entities.Task>> GetAllByEmployeeAsync(Guid employeeId)
        {
            return await _context.Tasks
                .AsNoTracking()
                .Where(x=> x.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task Remove(Guid taskId)
        {
            var task = await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == taskId);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Entities.Task> UpdateAsync(Guid taskId, Models.Entities.Task updateTask)
        {
            var task = await _context.Tasks
                //.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == taskId);
            task.DeadLine = updateTask.DeadLine;
            task.Description = updateTask.Description;
            task.EmployeeId = updateTask.EmployeeId;
            task.IsCompleted = updateTask.IsCompleted;
            task.Created = updateTask.Created;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
