namespace TaskManagement.API.DTOs.TaskAssignment
{
    public class TaskAssignmentCreateDto
    {
        public Guid TaskItemId { get; set; }
        public Guid UserId { get; set; }
    }
}
