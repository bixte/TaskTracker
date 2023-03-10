using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.Models.ProjectManagers.Date;

namespace TaskTracker.BLL.Interfaces
{
    public interface IProjectService
    {
        void CreateProject(ProjectPostDTO projectDTO);
        void UpdateProject(ProjectUpdateDTO projectDTO);
        ProjectDTO GetProject(int? id);
        IEnumerable<ProjectDTO> GetProjects(bool withTasks, ProjectStatus? filterByStatus, SortBy? sortByPriority, string? date, TypeSearchDate? typeSearchDate);
        void RemoveProject(int? id);
        void Dispose();
    }
}
