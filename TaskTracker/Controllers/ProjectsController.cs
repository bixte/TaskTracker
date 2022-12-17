using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskTracker.Bll.TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.BLL.Interfaces;
using TaskTracker.Models.ProjectManagers.Date;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IProjectTaskService projectTaskService;
        private readonly string success = "успешно";
        public ProjectsController(IProjectService projectService, IProjectTaskService projectTaskService)
        {
            this.projectService = projectService;
            this.projectTaskService = projectTaskService;
        }

        [HttpGet]
        public ActionResult Index(int? id, ProjectStatus? filterByStatus, SortBy? sortByPriority, string? date, TypeSearchDate? typeSearchDate)
        {
            try
            {
                if (id != null)
                {
                    var project = projectService.GetProject(id);
                    return Ok(project);
                }
                else
                {
                    var projectsTDO = projectService.GetProjects(filterByStatus, sortByPriority, date, typeSearchDate);
                    return Ok(projectsTDO);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult CreateProject(ProjectDTO projectDTO)
        {
            try
            {
                projectService.CreateProject(projectDTO);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        public ActionResult Update(ProjectUpdateDTO projectUpdateDTO)
        {
            projectService.UpdateProject(projectUpdateDTO);
            try
            {
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete]
        public ActionResult Remove(int id)
        {
            try
            {
                projectService.RemoveProject(id);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

        [HttpGet]
        [Route("/tasks")]
        public ActionResult GetTasks([FromQuery] int? projectId, SortBy? sortPriority)
        {
            try
            {
                var projectsTasks = projectTaskService.GetProjectTasks(projectId, sortPriority);
                return Ok(projectsTasks);

            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }

        }

        [HttpGet]
        [Route("/tasks/{id}")]
        public ActionResult GetTask([FromRoute] int id)
        {
            try
            {
                var projectsTasks = projectTaskService.GetProjectTask(id);
                return Ok(projectsTasks);

            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }

        }

        [HttpPost]
        [Route("/tasks/")]
        public ActionResult CreateTask(ProjectTaskDTO task)
        {
            try
            {
                projectTaskService.CreateProjectTask(task);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

    }
}
