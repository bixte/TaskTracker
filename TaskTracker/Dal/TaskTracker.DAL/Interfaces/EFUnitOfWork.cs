using TaskTracker.DAL.EF;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Interfaces
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly TaskTrackerDB database;
        private ProjectRepository? projectRepository;
        private TaskRepository? taskRepository;
        private bool disposed = false;
        public EFUnitOfWork(TaskTrackerDB database)
        {
            this.database = database;
        }


        IRepository<Project> IUnitOfWork.ProjectRepository
        {
            get
            {
                if (projectRepository is null)
                    projectRepository = new(database);
                return projectRepository;
            }
        }

        IRepository<ProjectTask> IUnitOfWork.TaskRepository
        {
            get
            {
                if (taskRepository is null)
                    taskRepository = new(database);
                return taskRepository;
            }
        }

        public void Save()
        {
            database.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    database.Dispose();

                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
