using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskTracker.BLL.BusinessModels.ProjectManagers;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Filter;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.EF;
using TaskTracker.DAL.Entities;
using TaskTracker.Models.ProjectManagers;
using TaskTracker.Models.ProjectManagers.Date;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        readonly IProjectService projectService;
        private readonly TaskTrackerDB dataBase;

        public ProjectsController(IProjectService projectService, DAL.EF.TaskTrackerDB dataBase)
        {
            this.projectService = projectService;
            this.dataBase = dataBase;
        }

        [HttpGet]
        public ActionResult Index(int? id, ProjectStatus? filterByStatus, SortBy? sortByPriority, string? date, TypeSearchDate? typeSearchDate)
        {
            if (id != null)
            {
                var project = projectService.GetProject(id);
                return Ok(project);
            }

            else
            {
                //были отчаянные попытки реализовать сортировку и фильтр через сервисы, но не успел и поставил заглушку :(
                var projectManager = new ManagerProject<Project>();

                if (filterByStatus is ProjectStatus status)
                    projectManager.ProjectStatusFilter = new ProjectStatusFilter(status);

                if (sortByPriority is SortBy sort)
                    projectManager.SortByPriority = new SortPriority(sort);

                if (date != null && typeSearchDate is TypeSearchDate typeSearch)
                    projectManager.DateSearch = new ProjectDateSearch(date, typeSearch);

                var projectStore = new ProjectStore(dataBase.Projects, projectManager);
                var projects = projectStore.GetFilterAndSort();
                return Ok(projects);
            }
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectDTO projectDTO)
        {
            try
            {
                projectService.CreateProject(projectDTO);
                return Ok("успешно создан");
            }
            catch (ValidationException ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public ActionResult Update([FromRoute] int id, [FromBody] ProjectDTO projectDTO)
        {
            projectService.UpdateProject(projectDTO);
            try
            {
                return Ok(projectDTO);
            }
            catch (ValidationException ex) { return BadRequest(ex); }
        }

        [HttpDelete]
        public ActionResult Remove(int id)
        {
            try
            {
                projectService.RemoveProject(id);
                return Ok("успешно удален");
            }
            catch (ValidationException ex) { return BadRequest(ex); }
        }

        [HttpGet]
        [Route("/tasks")]
        public ActionResult GetTasks([FromQuery] int? projectId)
        {
            if (projectId != null)
            {
                var tasks =  dataBase.Tasks.Where(t => t.ProjectId == projectId);
                if (tasks != null)
                    return Ok(tasks);
                else
                    return BadRequest("задания не найдены");
            }
            else
            {
                var allTasks = dataBase.Tasks;
                return Ok(allTasks);
            }

        }

        [HttpGet]
        [Route("/tasks/{id}")]
        public async Task<ActionResult> GetTask([FromRoute] int id)
        {
            var task = await dataBase.Tasks.FindAsync(id);
            if (task != null)
                return Ok(task);
            else
                return BadRequest("задание не найдено");

        }

        [HttpPost]
        [Route("/tasks/")]
        public async Task<ActionResult> CreateTask(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                var project = await dataBase.Projects.FindAsync(task.ProjectId);
                if (project != null)
                {
                    await dataBase.Tasks.AddAsync(task);
                    await dataBase.SaveChangesAsync();
                }
                return Ok("успешно");
            }
            else
                return BadRequest("модель оказалась не валидной");
        }

    }
}
