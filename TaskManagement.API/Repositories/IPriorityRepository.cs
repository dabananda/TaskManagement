using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public interface IPriorityRepository
    {
        Task<Priority> CreateAsync(Priority priority);
        Task<Priority?> GetByIdAsync(Guid id);
        Task<IEnumerable<Priority>> GetAllAsync();
        Task<Priority> UpdateAsync(Priority priority);
        Task<Priority> DeleteAsync(Guid id);
    }
}
