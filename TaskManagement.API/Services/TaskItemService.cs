using AutoMapper;
using TaskManagement.API.DTOs.TaskItem;
using TaskManagement.API.Models;
using TaskManagement.API.Repositories.Interfaces;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public TaskItemService(ITaskItemRepository taskRepo, IUserRepository userRepository, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _userRepo = userRepository;
            _mapper = mapper;
        }
        public async Task<TaskItemReadDto> CreateAsync(TaskItemCreateDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);

            // Assign users to the task
            if (dto.AssignedUserIds != null && dto.AssignedUserIds.Any())
            {
                task.TaskAssignments = new List<TaskAssignment>();
                foreach (var userId in dto.AssignedUserIds)
                {
                    var user = await _userRepo.GetByIdAsync(userId);
                    if (user != null)
                    {
                        task.TaskAssignments.Add(new TaskAssignment
                        {
                            UserId = user.Id,
                            TaskItemId = task.Id,
                            AssignedAt = DateTime.UtcNow
                        });
                    }
                }
            }

            await _taskRepo.AddAsync(task);
            await _taskRepo.SaveChangesAsync();

            return _mapper.Map<TaskItemReadDto>(task);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null) return false;
            await _taskRepo.DeleteAsync(task);
            return await _taskRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItemReadDto>> GetAllAsync()
        {
            var tasks = await _taskRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskItemReadDto>>(tasks);
        }

        public async Task<TaskItemReadDto> GetByIdAsync(Guid id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null) return null;
            return _mapper.Map<TaskItemReadDto>(task);
        }

        public async Task<bool> UpdateAsync(Guid id, TaskItemUpdateDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            if (task == null) return false;
            _mapper.Map(dto, task);

            // Reassign users if provided
            if (dto.AssignedUserIds != null)
            {
                task.TaskAssignments.Clear();
                foreach (var userId in dto.AssignedUserIds)
                {
                    var user = await _userRepo.GetByIdAsync(userId);
                    if (user != null)
                    {
                        task.TaskAssignments.Add(new TaskAssignment
                        {
                            UserId = user.Id,
                            TaskItemId = task.Id,
                            AssignedAt = DateTime.UtcNow
                        });
                    }
                }
            }

            await _taskRepo.UpdateAsync(task);
            return await _taskRepo.SaveChangesAsync();
        }
    }
}
