using TaskManagement.API.DTOs.TaskItem;
using TaskManagement.API.Models;

namespace TaskManagement.API.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemReadDto>> GetAllAsync();
        Task<TaskItemReadDto> GetByIdAsync(Guid id);
        Task<TaskItemReadDto> CreateAsync(TaskItemCreateDto dto);
        Task<bool> UpdateAsync(Guid id, TaskItemUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
