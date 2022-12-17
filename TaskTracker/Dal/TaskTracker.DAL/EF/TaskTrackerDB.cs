using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Entity;

namespace TaskTracker.DAL.EF
{
    public class TaskTrackerDB : DbContext
    {

        public TaskTrackerDB(DbContextOptions options) : base(options)
        {
            if (Database.EnsureCreated())
                Database.Migrate();
        }

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<ProjectTask> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var projectEntity = modelBuilder.Entity<Project>();
            projectEntity.Property(p => p.StartDate).HasColumnType("smalldatetime");
            projectEntity.Property(p => p.EndDate).HasColumnType("smalldatetime");
            projectEntity.Property(p => p.Status).HasDefaultValue("NotStarted");
            projectEntity.Property(p => p.Priority).HasDefaultValue(0);

            var projectTaskEntity = modelBuilder.Entity<ProjectTask>();
            projectTaskEntity.Property(t => t.Status).HasDefaultValue("ToDo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
