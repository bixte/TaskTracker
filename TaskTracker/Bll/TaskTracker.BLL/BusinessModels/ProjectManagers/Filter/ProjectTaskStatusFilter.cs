using TaskTracker.BLL.DTO.Project;
using TaskTracker.DAL.Entity;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public class ProjectTaskStatusFilter : IFilter<ProjectTask>
    {
        private readonly ProjectStatus? projectStatus;

        public ProjectTaskStatusFilter(ProjectStatus? projectStatus)
        {

            this.projectStatus = projectStatus;
        }

        public IQueryable<ProjectTask> Filter(IQueryable<ProjectTask> items)
        {
            if (projectStatus != null)
                return items.Where(i => i.Status == projectStatus.Value.ToString());
            else
                return items;

        }
    }

}
