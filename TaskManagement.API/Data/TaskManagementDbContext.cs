using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Models;

namespace TaskManagement.API.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for TaskAssignment
            modelBuilder.Entity<TaskAssignment>()
                .HasKey(ta => new { ta.UserId, ta.TaskItemId });

            // Relationships
            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.User)
                .WithMany(u => u.TaskAssignments)
                .HasForeignKey(ta => ta.UserId);

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(ta => ta.TaskItem)
                .WithMany(t => t.TaskAssignments)
                .HasForeignKey(ta => ta.TaskItemId);

            // Default timestamps
            modelBuilder.Entity<TaskItem>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
