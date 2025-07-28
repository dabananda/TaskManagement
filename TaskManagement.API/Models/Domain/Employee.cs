namespace TaskManagement.API.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid DesignationId { get; set; }
        public Designation Designation { get; set; }
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
