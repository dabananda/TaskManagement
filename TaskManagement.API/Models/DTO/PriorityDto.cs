using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Models.DTO
{
    public class PriorityDto
    {
        public Guid Id { get; set; }
        public string Level { get; set; }
        public ICollection<TaskItem>? TaskItems { get; set; }
    }
}
