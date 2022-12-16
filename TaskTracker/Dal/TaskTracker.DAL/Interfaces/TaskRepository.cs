using TaskTracker.DAL.EF;
using TaskTracker.DAL.Entities;

namespace TaskTracker.DAL.Interfaces
{
    public class TaskRepository : IRepository<ProjectTask>
    {
        private readonly TaskTrackerDB dataBase;

        public TaskRepository(TaskTrackerDB dataBase) => this.dataBase = dataBase;
        public void Create(ProjectTask item) => dataBase.Tasks.Add(item);

        public void Delete(ProjectTask item) => dataBase.Tasks.Remove(item);

        public ProjectTask Get(int id) => dataBase.Tasks.Find(id) ?? throw new Exception();

        public IEnumerable<ProjectTask> GetAll() => dataBase.Tasks;

   

        public void Update(ProjectTask item)
        {
            dataBase.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
