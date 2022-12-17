namespace TaskTracker.Models.ProjectManagers.Sort
{
    public interface ISort<T>
    {
        public IQueryable<T> Sort(IQueryable<T> items);
    }
}
