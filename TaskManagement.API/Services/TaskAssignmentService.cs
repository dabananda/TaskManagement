using AutoMapper;
using TaskManagement.API.DTOs.TaskAssignment;
using TaskManagement.API.Models;
using TaskManagement.API.Repositories.Interfaces;
using TaskManagement.API.Services.Interfaces;

namespace TaskManagement.API.Services
{
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly ITaskAssignmentRepository _assignmentRepo;
        private readonly IMapper _mapper;

        public TaskAssignmentService(ITaskAssignmentRepository assignmentRepo, IMapper mapper)
        {
            _assignmentRepo = assignmentRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskAssignmentReadDto>> GetAllAsync()
        {
            var assignments = await _assignmentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskAssignmentReadDto>>(assignments);
        }

        public async Task<TaskAssignmentReadDto?> GetByIdAsync(Guid id)
        {
            var assignment = await _assignmentRepo.GetByIdAsync(id);
            return assignment == null ? null : _mapper.Map<TaskAssignmentReadDto>(assignment);
        }

        public async Task<TaskAssignmentReadDto> CreateAsync(TaskAssignmentCreateDto dto)
        {
            var entity = _mapper.Map<TaskAssignment>(dto);
            await _assignmentRepo.AddAsync(entity);
            await _assignmentRepo.SaveChangesAsync();
            return _mapper.Map<TaskAssignmentReadDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var assignment = await _assignmentRepo.GetByIdAsync(id);
            if (assignment == null) return false;
            _assignmentRepo.Remove(assignment);
            return await _assignmentRepo.SaveChangesAsync();
        }
    }
}
