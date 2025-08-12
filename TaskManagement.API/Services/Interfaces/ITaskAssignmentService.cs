using TaskManagement.API.DTOs.TaskAssignment;

namespace TaskManagement.API.Services.Interfaces
{
    public interface ITaskAssignmentService
    {
        Task<IEnumerable<TaskAssignmentReadDto>> GetAllAsync();
        Task<TaskAssignmentReadDto?> GetByIdAsync(Guid id);
        Task<TaskAssignmentReadDto> CreateAsync(TaskAssignmentCreateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
