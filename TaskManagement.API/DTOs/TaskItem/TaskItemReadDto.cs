using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.DTOs.TaskItem
{
    public class TaskItemReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<UserDto> AssignedUsers { get; set; }
    }
}
