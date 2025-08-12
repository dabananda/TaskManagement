using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models;

namespace TaskManagement.API.Repositories
{
    public class TaskAssignmentRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskAssignmentRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskAssignment>> GetAllAsync()
        {
            return await _context.TaskAssignments
                .Include(t => t.TaskItem)
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<TaskAssignment?> GetByIdAsync(Guid id)
        {
            return await _context.TaskAssignments
                .Include(t => t.TaskItem)
                .Include(t => t.User)
                .FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task AddAsync(TaskAssignment assignment)
        {
            await _context.TaskAssignments.AddAsync(assignment);
        }

        public void Remove(TaskAssignment assignment)
        {
            _context.TaskAssignments.Remove(assignment);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
