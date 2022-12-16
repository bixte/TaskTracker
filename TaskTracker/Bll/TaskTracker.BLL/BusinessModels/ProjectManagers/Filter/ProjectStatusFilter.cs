using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public interface IProjectStatusFilter : IFilter<Project>
    {
    }


    public class ProjectStatusFilter : IProjectStatusFilter
    {
        private readonly ProjectStatus projectStatus;

        public ProjectStatusFilter(ProjectStatus projectStatus)
        {

            this.projectStatus = projectStatus;
        }

        public IQueryable<Project> Filter(IQueryable<Project> projects) => projects.Where(p => p.Status == projectStatus.ToString());
    }
}
