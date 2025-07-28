using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
    }
}
