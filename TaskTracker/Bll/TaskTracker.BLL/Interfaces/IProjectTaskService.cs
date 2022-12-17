using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.ProjectTask;

namespace TaskTracker.Bll.TaskTracker.BLL.Interfaces
{
    public interface IProjectTaskService
    {
        void CreateProjectTask(ProjectTaskDTO projectDTO);
        void UpdateProjectTask(ProjectTaskDTO projectDTO);
        ProjectTaskDTO GetProjectTask(int? id);
        IEnumerable<ProjectTaskDTO> GetProjectTasks(int? projectId, SortBy? sortPriority);
        void RemoveProjectTask(int? id);
        void Dispose();
    }
}
