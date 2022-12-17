using System.ComponentModel.DataAnnotations;
using TaskTracker.DAL.EF;
using TaskTracker.DAL.Entity;

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
            var project = dataBase.Projects.Find(id);
            if (project == null)
                throw new ValidationException("не найден");

            dataBase.Entry(project).Collection(p => p.Tasks).Load();
            return project;
        }

        public IQueryable<Project> GetAll() => dataBase.Projects;

        public void Update(Project item)
        {
            dataBase.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataBase.SaveChanges();
        }
    }
}
