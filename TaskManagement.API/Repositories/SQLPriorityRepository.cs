using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public class SQLPriorityRepository : IPriorityRepository
    {
        private readonly TaskManagementDbContext dbContext;

        public SQLPriorityRepository(TaskManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Priority> CreateAsync(Priority priority)
        {
            await dbContext.Priorities.AddAsync(priority);
            await dbContext.SaveChangesAsync();
            return priority;
        }

        public async Task<Priority> DeleteAsync(Guid id)
        {
            var priority = await dbContext.Priorities.FirstOrDefaultAsync(x => x.Id == id);

            if (priority == null)
            {
                return null;
            }

            dbContext.Priorities.Remove(priority);
            await dbContext.SaveChangesAsync();

            return priority;
        }

        public async Task<IEnumerable<Priority>> GetAllAsync()
        {
            return await dbContext.Priorities.Include(x => x.TaskItems).ToListAsync();
        }

        public async Task<Priority?> GetByIdAsync(Guid id)
        {
            return await dbContext.Priorities.Include(x => x.TaskItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Priority> UpdateAsync(Guid id, Priority priority)
        {
            var existingPriority = await dbContext.Priorities.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPriority == null)
            {
                return null;
            }

            existingPriority.Level = priority.Level;
            existingPriority.TaskItems = priority.TaskItems;

            await dbContext.SaveChangesAsync();

            return existingPriority;
        }
    }
}
