using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public interface IProjectStatusFilter : IFilter<Project>
    {
    }


    public class ProjectStatusFilter : IProjectStatusFilter
    {
        private readonly ProjectStatus? projectStatus;

        public ProjectStatusFilter(ProjectStatus? projectStatus)
        {

            this.projectStatus = projectStatus;
        }

        public IEnumerable<Project> Filter(IEnumerable<Project> items)
        {
            if (projectStatus != null)
                return items.Where(i => i.Status == projectStatus.Value.ToString());
            else
               return items;
            
        }
    }
}
