using Microsoft.EntityFrameworkCore;
using Task = TaskAPI.Entities.Task;

namespace TaskAPI.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<Task> Tasks { get; set; }
    }
}
