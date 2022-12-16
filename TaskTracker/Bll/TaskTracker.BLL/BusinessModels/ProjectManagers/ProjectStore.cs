using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Entities;
using TaskTracker.Models.ProjectManagers;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers
{
    public class ProjectStore
    {
        private IQueryable<Project> projects;
        private readonly ManagerProject<Project> managerItems;

        public ProjectStore(IQueryable<Project> projects, ManagerProject<Project> managerItems)
        {
            this.projects = projects;
            this.managerItems = managerItems;
        }

        public IQueryable<Project> GetFilterAndSort()
        {
            if (managerItems.DateSearch != null)
                projects = managerItems.DateSearch.Search(projects);
            if (managerItems.ProjectStatusFilter !=null)
                projects = managerItems.ProjectStatusFilter.Filter(projects);
            if (managerItems.SortByPriority !=null)
                projects = managerItems.SortByPriority.Sort(projects);

            return projects.Include(p=>p.Tasks);
        }
    }
}
