using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.DTOs.TaskItem
{
    public class TaskItemUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public List<Guid> AssignedUserIds { get; set; }
    }
}
