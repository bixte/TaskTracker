using TaskTracker.Bll.TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.ProjectTask;

namespace TaskTracker.Bll.TaskTracker.BLL.Interfaces
{
    public interface IProjectTaskService
    {
        void CreateProjectTask(ProjectTaskPostDTO projectDTO);
        void UpdateProjectTask(ProjectTaskUpdateDTO projectDTO);
        ProjectTaskDTO GetProjectTask(int? id);
        IEnumerable<ProjectTaskDTO> GetProjectTasks(SortBy? sortPriority);
        void RemoveProjectTask(int? id);
        void Dispose();
    }
}
