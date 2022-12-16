using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.Models.ProjectManagers.Date;
using TaskTracker.Models.ProjectManagers.Sort;

namespace TaskTracker.Models.ProjectManagers
{
    public class ManagerProject<T>
    {
        public IFilter<T>? ProjectStatusFilter { get; set; }
        public ISort<T>? SortByPriority { get; set; }
        public ISearchByDate<T>? DateSearch { get; set; }

    }
}
