using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Entity;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Links
{
    public class TaskLink : ILink<Project>
    {
        private readonly bool withTasks;

        public TaskLink(bool withTasks)
        {
            this.withTasks = withTasks;
        }
        public IQueryable<Project> Load(IQueryable<Project> items)
        {
            if (withTasks)
                return items.Include(i => i.Tasks);

            return items;
        }

    }
}
