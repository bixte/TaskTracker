using TaskTracker.DAL.Entity;
using TaskTracker.Models.ProjectManagers.Sort;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Sort
{
    public class SortTaskPriority : ISort<ProjectTask>
    {
        private readonly SortBy? sortBy;

        public SortTaskPriority(SortBy? sortBy)
        {
            this.sortBy = sortBy;
        }
        public IQueryable<ProjectTask> Sort(IQueryable<ProjectTask> tasks)
        {
            if (sortBy == null)
                return tasks;
            else
            {
                if (sortBy == SortBy.Desc)
                    return tasks.OrderByDescending(p => p.Priority);
                else
                    return tasks.OrderBy(p => p.Priority);
            }

        }
    }
}
