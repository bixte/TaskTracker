using TaskTracker.DAL.Entities;
using TaskTracker.Models.ProjectManagers.Sort;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Sort
{
    public interface ISortPriority : ISort<Project>
    {
    }

    public class SortPriority : ISortPriority
    {
        private readonly SortBy? sortBy;

        public SortPriority(SortBy? sortBy)
        {
            this.sortBy = sortBy;
        }
        public IQueryable<Project> Sort(IQueryable<Project> projects)
        {
            if (sortBy == SortBy.Desc)
                return projects.OrderByDescending(p => p.Priority);
            else
                return projects.OrderBy(p => p.Priority);
        }
    }
}
