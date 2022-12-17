namespace TaskTracker.Models.ProjectManagers.Date
{
    public interface ISearchByDate<T>
    {
        public IQueryable<T> Search(IQueryable<T> items);

    }
}
