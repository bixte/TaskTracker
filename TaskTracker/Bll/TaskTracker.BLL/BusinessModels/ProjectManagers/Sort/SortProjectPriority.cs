using TaskTracker.DAL.Entity;
using TaskTracker.Models.ProjectManagers.Sort;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Sort
{
    public class SortProjectPriority : ISort<Project>
    {
        private readonly SortBy? sortBy;

        public SortProjectPriority(SortBy? sortBy)
        {
            this.sortBy = sortBy;
        }
        public IQueryable<Project> Sort(IQueryable<Project> tasks)
        {
            if (sortBy != null)
            {
                if (sortBy == SortBy.Desc)
                    return tasks.OrderByDescending(t => t.Priority);
                else
                    return tasks.OrderBy(p => p.Priority);
            }
            else
                return tasks;

        }
    }
}
