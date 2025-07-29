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

        public Task<Priority> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Priority>> GetAllAsync()
        {
            return await dbContext.Priorities.Include(x => x.TaskItems).ToListAsync();
        }

        public async Task<Priority?> GetByIdAsync(Guid id)
        {
            return await dbContext.Priorities.Include(x => x.TaskItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Priority> UpdateAsync(Priority priority)
        {
            throw new NotImplementedException();
        }
    }
}
