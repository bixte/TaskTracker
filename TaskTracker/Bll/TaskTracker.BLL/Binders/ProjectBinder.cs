using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.Binders
{
    public class ProjectBinder : IBinder<Project>
    {
        private readonly Project project;
        private readonly string? name;
        private readonly DateTime? startDate;
        private readonly DateTime? endDate;
        private readonly DTO.Project.ProjectStatus? status;
        private readonly int? priority;

        public ProjectBinder(Project project, string? name, DateTime? startDate, DateTime? endDate, DTO.Project.ProjectStatus? status, int? priority)
        {
            this.project = project;
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
            this.status = status;
            this.priority = priority;
        }
        public Project Bind()
        {
            if (name != null)
                project.Name = name;

            if (startDate.HasValue)
                project.StartDate = startDate;

            if (endDate.HasValue)
                project.EndDate = endDate;

            if (status != null)
                project.Status = status.Value.ToString();

            if (priority > 0)
                project.Priority = priority.Value;

            return project;
        }
    }
}
