namespace TaskTracker.Models.ProjectManagers.Sort
{
    public interface ISort<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> items);
    }
}
