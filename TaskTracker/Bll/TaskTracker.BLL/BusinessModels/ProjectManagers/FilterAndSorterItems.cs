using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.Models.ProjectManagers.Date;
using TaskTracker.Models.ProjectManagers.Sort;

namespace TaskTracker.Models.ProjectManagers
{
    public class FilterAndSorterItems<T>
    {
        private readonly IFilter<T>? ProjectStatusFilter;
        private readonly ISort<T>? SortByPriority;
        private readonly ISearchByDate<T>? DateSearch;
        public FilterAndSorterItems(IFilter<T>? projectStatusFilter, ISort<T>? sortByPriority, ISearchByDate<T>? dateSearch)
        {
            ProjectStatusFilter = projectStatusFilter;
            SortByPriority = sortByPriority;
            DateSearch = dateSearch;
        }

        public IEnumerable<T> Process(IEnumerable<T> items)
        {
            if (ProjectStatusFilter != null)
                items = ProjectStatusFilter.Filter(items);
            if (SortByPriority != null)
                items = SortByPriority.Sort(items);
            if (DateSearch != null)
                items = DateSearch.Search(items);

            return items;
        }
    }
}
