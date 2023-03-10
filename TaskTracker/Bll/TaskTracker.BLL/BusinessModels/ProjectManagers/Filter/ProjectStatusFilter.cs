using TaskTracker.BLL.DTO.Project;
using TaskTracker.DAL.Entity;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public class ProjectStatusFilter : IFilter<Project>
    {
        private readonly ProjectStatus? projectStatus;

        public ProjectStatusFilter(ProjectStatus? projectStatus)
        {

            this.projectStatus = projectStatus;
        }

        public IQueryable<Project> Filter(IQueryable<Project> items)
        {
            if (projectStatus != null)
                return items.Where(i => i.Status == projectStatus.Value.ToString());
            else
                return items;

        }
    }
}
