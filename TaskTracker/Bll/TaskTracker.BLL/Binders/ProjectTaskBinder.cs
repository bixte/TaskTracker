using TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.DAL.Entity;

namespace TaskTracker.BLL.Binders
{
    public class ProjectTaskBinder : IBinder<ProjectTask>
    {
        private readonly ProjectTask projectTask;
        private readonly string? name;
        private readonly string? description;
        private readonly int? priority;
        private readonly DTO.ProjectTask.ProjectTaskStatus? status;

        public ProjectTaskBinder(ProjectTask projectTask, string? name, string? description, int? priority, ProjectTaskStatus? status)
        {
            this.projectTask = projectTask;
            this.name = name;
            this.description = description;
            this.priority = priority;
            this.status = status;
        }
        public ProjectTask Bind()
        {
            if (name != null)
                projectTask.Name = name;

            if (description != null)
                projectTask.Description = description;

            if (status.HasValue)
                projectTask.Status = status.Value.ToString();

            if (priority.HasValue)
                projectTask.Priority = priority.Value;

            return projectTask;
        }
    }
}
