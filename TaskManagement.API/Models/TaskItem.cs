using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskItemStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
