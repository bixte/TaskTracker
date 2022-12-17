using TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.DAL.Entity;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public class ProjectTaskFilter : IFilter<ProjectTask>
    {
        private readonly ProjectTaskStatus? taskStatus;

        public ProjectTaskFilter(ProjectTaskStatus? taskStatus)
        {
            this.taskStatus = taskStatus;
        }
        public IQueryable<ProjectTask> Filter(IQueryable<ProjectTask> tasks)
        {
            return taskStatus != null ? tasks.Where(t => t.Status == taskStatus.Value.ToString()) : tasks;
        }
    }
}
