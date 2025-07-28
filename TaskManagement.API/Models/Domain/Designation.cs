namespace TaskManagement.API.Models.Domain
{
    public class Designation
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
