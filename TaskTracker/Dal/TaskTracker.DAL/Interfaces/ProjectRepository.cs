using TaskTracker.DAL.EF;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Interfaces
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly TaskTrackerDB dataBase;

        public ProjectRepository(TaskTrackerDB dataBase)
        {
            this.dataBase = dataBase;
        }
        public void Create(Project item)
        {
            dataBase.Projects.Add(item);
            dataBase.SaveChanges();
        }

        public void Delete(Project item)
        {
            dataBase.Projects.Remove(item);
            dataBase.SaveChanges();
        }

        public Project Get(int id)
        {
            return dataBase.Projects.Find(id) ?? throw new Exception("не найден");
        }

        public IEnumerable<Project> GetAll() => dataBase.Projects;

        public void Update(Project item)
        {
            dataBase.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataBase.SaveChanges();
        }
    }
}
