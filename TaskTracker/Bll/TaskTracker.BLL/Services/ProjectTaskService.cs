using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskTracker.Bll.TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.DAL.Entities;
using TaskTracker.DAL.Interfaces;

namespace TaskTracker.Bll.TaskTracker.BLL.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IUnitOfWork DataBase;
        public ProjectTaskService(IUnitOfWork dataBase)
        {
            DataBase = dataBase;
        }
        public void Dispose() => DataBase.Dispose();
        public void CreateProjectTask(ProjectTaskDTO projectTaskDTO)
        {
            var context = new ValidationContext(projectTaskDTO);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(projectTaskDTO, context, results))
            {
                var exceptionMessage = new StringBuilder();
                foreach (var result in results)
                    exceptionMessage.Append(result.ErrorMessage + '\n');
                throw new Exception(exceptionMessage.ToString());

            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTaskDTO, ProjectTask>()).CreateMapper();
            var projectTask = mapper.Map<ProjectTaskDTO, ProjectTask>(projectTaskDTO);

            DataBase.TaskRepository.Create(projectTask);
        }



        public ProjectTaskDTO GetProjectTask(int? id)
        {
            if (id is null)
                throw new ValidationException("id не указан");

            var projectTask = DataBase.TaskRepository.Get(id.Value);
            if (projectTask is null)
                throw new ValidationException("не удалось найти");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTask, ProjectTaskDTO>()).CreateMapper();
            var projectTaskDTO = mapper.Map<ProjectTask, ProjectTaskDTO>(projectTask);

            return projectTaskDTO;

        }

        public IEnumerable<ProjectTaskDTO> GetProjectTasks(int? projectId, SortBy? sortByPriority)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTask, ProjectTaskDTO>()).CreateMapper();
            var projectTasks = DataBase.TaskRepository.GetAll();

            var projectTasksDTO = mapper.Map<IEnumerable<ProjectTask>, IEnumerable<ProjectTaskDTO>>(projectTasks);
            if (projectId != null)
                return projectTasksDTO.Where(t => t.ProjectId == projectId.Value);

            return projectTasksDTO;
        }

        public void RemoveProjectTask(int? id)
        {
            if (id is null)
                throw new ValidationException("id не указан");
            var projectTask = DataBase.TaskRepository.Get(id.Value);
            if (projectTask is null)
                throw new ValidationException("не удалось найти");

            DataBase.TaskRepository.Delete(projectTask);
        }

        public void UpdateProjectTask(ProjectTaskDTO projectTaskDTO)
        {
            if (projectTaskDTO.Id is null)
                throw new ValidationException("id не указан");

            var projectTask = DataBase.TaskRepository.Get(projectTaskDTO.Id.Value);
            var projectTaskUpdate = new ProjectTask
            {
                Id = projectTaskDTO.Id.Value,
                Name = projectTaskDTO.Name is null ? projectTask.Name : projectTaskDTO.Name,
                Description = projectTaskDTO.Description is null ? projectTask.Description : projectTaskDTO.Description,
                Status = projectTaskDTO.Status is null ? projectTask.Status : projectTaskDTO.Status.Value.ToString(),
                Priority = projectTaskDTO.Priority is null ? projectTask.Priority : projectTaskDTO.Priority,
                ProjectId = projectTaskDTO.ProjectId > 0 ? projectTask.ProjectId : projectTaskDTO.ProjectId
            };


            DataBase.TaskRepository.Update(projectTaskUpdate);
        }

    }
}
