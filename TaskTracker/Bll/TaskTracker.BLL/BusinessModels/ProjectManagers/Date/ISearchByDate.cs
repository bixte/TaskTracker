namespace TaskTracker.Models.ProjectManagers.Date
{
    public interface ISearchByDate<T>
    {
        public IEnumerable<T> Search(IEnumerable<T> items);

    }
}
