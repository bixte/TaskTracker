namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Links
{
    public interface ILink<T>
    {
        public IQueryable<T> Load(IQueryable<T> items);
    }
}
