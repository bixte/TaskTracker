using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Links;
using TaskTracker.Models.ProjectManagers.Date;
using TaskTracker.Models.ProjectManagers.Sort;

namespace TaskTracker.Models.ProjectManagers
{
    public class FilterAndSorterItems<T>
    {
        private readonly IFilter<T>? StatusFilter;
        private readonly ISort<T>? SortByPriority;
        private readonly ISearchByDate<T>? DateSearch;
        private readonly ILink<T>? link;

        public FilterAndSorterItems(IFilter<T>? StatusFilter, ISort<T>? sortByPriority, ISearchByDate<T>? dateSearch, ILink<T>? link)
        {
            this.StatusFilter = StatusFilter;
            SortByPriority = sortByPriority;
            DateSearch = dateSearch;
            this.link = link;
        }

        public IQueryable<T> Process(IQueryable<T> items)
        {
            if (StatusFilter != null)
                items = StatusFilter.Filter(items);
            if (SortByPriority != null)
                items = SortByPriority.Sort(items);
            if (DateSearch != null)
                items = DateSearch.Search(items);
            if (link != null)
                items = link.Load(items);

            return items;
        }
    }
}
