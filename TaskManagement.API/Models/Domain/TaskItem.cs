namespace TaskManagement.API.Models.Domain
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed,
        OnHold,
        Cancelled
    }

    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
