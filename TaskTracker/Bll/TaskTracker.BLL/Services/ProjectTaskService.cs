using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TaskTracker.Bll.TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.Bll.TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.Binders;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.DAL.Entity;
using TaskTracker.DAL.Interfaces;
using TaskTracker.Models.ProjectManagers;

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
        public void CreateProjectTask(ProjectTaskPostDTO projectTaskDTO)
        {
            var project = DataBase.ProjectRepository.Get(projectTaskDTO.ProjectId);
            if (project == null)
                throw new ValidationException("указан id несущестующего проекта");

            var context = new ValidationContext(projectTaskDTO);
            var results = new List<ValidationResult>();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTaskPostDTO, ProjectTask>()).CreateMapper();
            var projectTask = mapper.Map<ProjectTaskPostDTO, ProjectTask>(projectTaskDTO);

            DataBase.TaskRepository.Create(projectTask);
            DataBase.Save();

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

        public IEnumerable<ProjectTaskDTO> GetProjectTasks(SortBy? sortByPriority, ProjectTaskStatus? filterByStatus)
        {
            var projectTasks = DataBase.TaskRepository.GetAll();

            var filterAndSorterItems = new FilterAndSorterItems<ProjectTask>(new ProjectTaskFilter(filterByStatus), new SortTaskPriority(sortByPriority), null, null);
            var collectTasks = filterAndSorterItems.Process(projectTasks).AsEnumerable();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTask, ProjectTaskDTO>()).CreateMapper();

            var projectTasksDTO = mapper.Map<IEnumerable<ProjectTask>, IEnumerable<ProjectTaskDTO>>(collectTasks);

            return projectTasksDTO;
        }

        public void RemoveProjectTask(int? id)
        {
            if (id is null)
                throw new ValidationException("id не указан");
            var projectTask = DataBase.TaskRepository.Get(id.Value);

            DataBase.TaskRepository.Delete(projectTask);
        }

        public void UpdateProjectTask(ProjectTaskUpdateDTO projectTaskDTO)
        {
            if (projectTaskDTO.Id is null)
                throw new ValidationException("id не указан");

            var projectTask = DataBase.TaskRepository.Get(projectTaskDTO.Id.Value);

            var projectTaskBinder = new ProjectTaskBinder(projectTask, projectTaskDTO.Name, projectTaskDTO.Description, projectTaskDTO.Priority, projectTaskDTO.Status);
            var updateProject = projectTaskBinder.Bind();

            DataBase.TaskRepository.Update(updateProject);
            DataBase.Save();
        }

    }
}
