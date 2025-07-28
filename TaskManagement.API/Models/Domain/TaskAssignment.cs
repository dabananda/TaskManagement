namespace TaskManagement.API.Models.Domain
{
    public class TaskAssignment
    {
        public Guid TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime AssignedAt { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
