namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Filter
{
    public interface IFilter<T>
    {
        public IQueryable<T> Filter(IQueryable<T> items);
    }
}
