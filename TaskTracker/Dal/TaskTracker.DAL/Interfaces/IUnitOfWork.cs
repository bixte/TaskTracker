using TaskTracker.DAL.Entity;

namespace TaskTracker.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Project> ProjectRepository { get; }
        public IRepository<ProjectTask> TaskRepository { get; }
        void Save();
    }
}
