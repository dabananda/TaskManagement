using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Models.DTO
{
    public class UpdatePriorityRequestDto
    {
        public string Level { get; set; }
        public ICollection<TaskItem>? TaskItems { get; set; }
    }
}
