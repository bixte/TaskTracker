﻿using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Entities;
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
        public void CreateProject(ProjectDTO projectDTO)
        {
            var context = new ValidationContext(projectDTO);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(projectDTO, context, results))
            {
                var exceptionMessage = new StringBuilder();
                foreach (var result in results)
                    exceptionMessage.Append(result.ErrorMessage + '\n');
                throw new Exception(exceptionMessage.ToString());
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, Project>()).CreateMapper();
            var project = mapper.Map<ProjectDTO, Project>(projectDTO);
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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();
            return mapper.Map<Project, ProjectDTO>(project);

        }

        public IEnumerable<ProjectDTO> GetProjects(ProjectStatus? filterByStatus,
                                                   SortBy? sortByPriority,
                                                   string? date,
                                                   TypeSearchDate? typeSearchDate)
        {

            var projects = DataBase.ProjectRepository.GetAll();
            projects = SortAndFilter(projects, filterByStatus, sortByPriority, date, typeSearchDate);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(projects);


        }

        private static IEnumerable<Project> SortAndFilter(IEnumerable<Project> projects,
                                                   ProjectStatus? filterByStatus,
                                                   SortBy? sortByPriority,
                                                   string? date,
                                                   TypeSearchDate? typeSearchDate)
        {
            var filterAndSort = new FilterAndSorterItems<Project>(new ProjectStatusFilter(filterByStatus),
                                                                  new SortPriority(sortByPriority),
                                                                  new DateSearch(date, typeSearchDate));
            return filterAndSort.Process(projects);

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

            if (projectUpdateDTO.Name != null)
                project.Name = projectUpdateDTO.Name;

            if (projectUpdateDTO.StartDate.HasValue)
                project.StartDate = projectUpdateDTO.StartDate;

            if (projectUpdateDTO.EndDate.HasValue)
                project.EndDate = projectUpdateDTO.EndDate;

            if (projectUpdateDTO.Status != null)
                project.Status = projectUpdateDTO.Status.Value.ToString();

            if (projectUpdateDTO.Priority > 0)
                project.Priority = projectUpdateDTO.Priority;

            DataBase.ProjectRepository.Update(project);
            DataBase.Save();

        }
    }
}
