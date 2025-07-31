namespace TaskManagement.API.Models
{
    public class TaskAssignment
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
