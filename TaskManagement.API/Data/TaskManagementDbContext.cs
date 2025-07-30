using Microsoft.EntityFrameworkCore;

namespace TaskManagement.API.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> dbContextOptions) : base(dbContextOptions) { }
    }
}
