namespace TaskManagement.API.Models.Domain
{
    public class Priority
    {
        public Guid Id { get; set; }
        public string Level { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
