using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models;
using TaskManagement.API.Repositories.Interfaces;

namespace TaskManagement.API.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskItemRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
        }

        public async Task DeleteAsync(TaskItem taskItem)
        {
            _context.TaskItems.Remove(taskItem);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems
                .Include(t => t.TaskAssignments)
                .ThenInclude(ta => ta.User)
                .ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(Guid id)
        {
            return await _context.TaskItems
                .Include(t => t.TaskAssignments)
                .ThenInclude(ta => ta.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await Task.CompletedTask;
        }
    }
}
