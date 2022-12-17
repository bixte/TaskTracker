using System.ComponentModel.DataAnnotations;
using TaskTracker.DAL.EF;
using TaskTracker.DAL.Entity;

namespace TaskTracker.DAL.Interfaces
{
    public class TaskRepository : IRepository<ProjectTask>
    {
        private readonly TaskTrackerDB dataBase;

        public TaskRepository(TaskTrackerDB dataBase) => this.dataBase = dataBase;
        public void Create(ProjectTask task)
        {
            dataBase.Tasks.Add(task);
            dataBase.SaveChanges();
        }

        public void Delete(ProjectTask item)
        {
            dataBase.Tasks.Remove(item);
            dataBase.SaveChanges();
        }

        public ProjectTask Get(int id) => dataBase.Tasks.Find(id) ?? throw new ValidationException("не найден");

        public IQueryable<ProjectTask> GetAll() => dataBase.Tasks;
        public IQueryable<ProjectTask> GetAll(int projectId) => dataBase.Tasks.Where(t => t.ProjectId == projectId);



        public void Update(ProjectTask item)
        {
            dataBase.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataBase.SaveChanges();
        }


    }
}
