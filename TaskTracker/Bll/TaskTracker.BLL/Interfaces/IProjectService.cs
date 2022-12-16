using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO;
using TaskTracker.DAL.Entities;
using TaskTracker.Models.ProjectManagers.Date;

namespace TaskTracker.BLL.Interfaces
{
    public interface IProjectService
    {
        void CreateProject(ProjectDTO projectDTO);
        void UpdateProject(ProjectDTO projectDTO);
        ProjectDTO GetProject(int? id);
        IEnumerable<ProjectDTO> GetProjects(ProjectStatus? filterByStatus, SortBy? sortByPriority, string? date, TypeSearchDate? typeSearchDate);
        void RemoveProject(int? id);
        void Dispose();
    }
}
