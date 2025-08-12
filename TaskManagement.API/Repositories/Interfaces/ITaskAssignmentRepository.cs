using TaskManagement.API.Models;

namespace TaskManagement.API.Repositories.Interfaces
{
    public interface ITaskAssignmentRepository
    {
        Task<IEnumerable<TaskAssignment>> GetAllAsync();
        Task<TaskAssignment?> GetByIdAsync(Guid id);
        Task AddAsync(TaskAssignment assignment);
        void Remove(TaskAssignment assignment);
        Task<bool> SaveChangesAsync();
    }
}
