namespace TaskManagement.API.DTOs.TaskAssignment
{
    public class TaskAssignmentReadDto
    {
        public Guid Id { get; set; }
        public Guid TaskItemId { get; set; }
        public string TaskTitle { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
