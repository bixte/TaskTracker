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

        public ProjectTask Get(int id) => dataBase.Tasks.Find(id) ?? throw new Exception("не найден");

        public IEnumerable<ProjectTask> GetAll() => dataBase.Tasks;
        public IEnumerable<ProjectTask> GetAll(int projectId) => dataBase.Tasks.Where(t => t.ProjectId == projectId);



        public void Update(ProjectTask item)
        {
            dataBase.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
