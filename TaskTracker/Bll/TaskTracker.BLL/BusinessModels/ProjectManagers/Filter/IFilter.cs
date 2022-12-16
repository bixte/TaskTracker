namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public interface IFilter<T>
    {
        public IEnumerable<T> Filter(IEnumerable<T> items);
    }
}
