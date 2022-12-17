using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TaskTracker.BLL.Binders;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Links;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entity;
using TaskTracker.DAL.Interfaces;
using TaskTracker.Models.ProjectManagers;
using TaskTracker.Models.ProjectManagers.Date;

namespace TaskTracker.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork DataBase;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
        }
        public void CreateProject(ProjectPostDTO projectDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectPostDTO, Project>()).CreateMapper();
            var project = mapper.Map<ProjectPostDTO, Project>(projectDTO);
            DataBase.ProjectRepository.Create(project);
            DataBase.Save();
        }

        public void Dispose() => DataBase.Dispose();

        public ProjectDTO GetProject(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона");
            var project = DataBase.ProjectRepository.Get(id.Value);

            if (project == null)
                throw new ValidationException("Телефон не найден");

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<Project, ProjectTaskDTO>();
            }).CreateMapper();

            return mapper.Map<Project, ProjectDTO>(project);

        }

        public IEnumerable<ProjectDTO> GetProjects(bool withTasks, ProjectStatus? filterByStatus,
                                                   SortBy? sortByPriority,
                                                   string? date,
                                                   TypeSearchDate? typeSearchDate)
        {
            var projects = DataBase.ProjectRepository.GetAll();
            var collectProjects = CollectProjects(withTasks, projects, filterByStatus, sortByPriority, date, typeSearchDate);

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<ProjectTask, ProjectTaskDTO>();
            }).CreateMapper();

            return mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(collectProjects);


        }

        private static IEnumerable<Project> CollectProjects(bool withTasks, IQueryable<Project> projects,
                                                   ProjectStatus? filterByStatus,
                                                   SortBy? sortByPriority,
                                                   string? date,
                                                   TypeSearchDate? typeSearchDate)
        {
            var filterAndSort = new FilterAndSorterItems<Project>(new ProjectStatusFilter(filterByStatus),
                                                                  new SortProjectPriority(sortByPriority),
                                                                  new DateSearch(date, typeSearchDate), new TaskLink(withTasks));
            var assemblingProjects = filterAndSort.Process(projects);

            return assemblingProjects;
        }

        public void RemoveProject(int? id)
        {
            if (id == null)
                throw new ValidationException("не указан id");

            var project = DataBase.ProjectRepository.Get(id.Value);
            if (project == null)
                throw new ValidationException("не удалось найти по указанному id");

            DataBase.ProjectRepository.Delete(project);
        }

        public void UpdateProject(ProjectUpdateDTO projectUpdateDTO)
        {
            if (projectUpdateDTO.Id == null)
                throw new ValidationException("не указан id");

            var project = DataBase.ProjectRepository.Get(projectUpdateDTO.Id.Value);
            if (project == null)
                throw new ValidationException("id указан неверно");

            var projectBinder = new ProjectBinder(project, projectUpdateDTO.Name, projectUpdateDTO.StartDate, projectUpdateDTO.EndDate, projectUpdateDTO.Status, projectUpdateDTO.Priority);
            var projectUpdate = projectBinder.Bind();

            DataBase.ProjectRepository.Update(projectUpdate);
            DataBase.Save();

        }
    }
}
