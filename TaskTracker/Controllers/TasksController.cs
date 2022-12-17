using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskTracker.Bll.TaskTracker.BLL.DTO.ProjectTask;
using TaskTracker.Bll.TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.ProjectTask;
namespace TaskTracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IProjectTaskService projectTaskService;
        private readonly string success = "успешно";
        public TasksController(IProjectTaskService projectTaskService)
        {
            this.projectTaskService = projectTaskService;
            this.projectTaskService = projectTaskService;
        }

        public ActionResult GetTasks(SortBy? sortPriority, ProjectTaskStatus? filterByStatus)
        {
            try
            {
                var projectsTasks = projectTaskService.GetProjectTasks(sortPriority, filterByStatus);
                return Ok(projectsTasks);

            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }

        }


        [HttpGet("{id}")]
        public ActionResult GetTask(int id)
        {
            try
            {
                var projectsTasks = projectTaskService.GetProjectTask(id);
                return Ok(projectsTasks);

            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }

        }

        [HttpPost]
        public ActionResult CreateTask(ProjectTaskPostDTO task)
        {
            try
            {
                projectTaskService.CreateProjectTask(task);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }


        [HttpPut]
        public ActionResult UpdateTask(ProjectTaskUpdateDTO task)
        {
            try
            {
                projectTaskService.UpdateProjectTask(task);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete]
        public ActionResult DeleteTask([FromQuery] int id)
        {
            try
            {
                projectTaskService.RemoveProjectTask(id);
                return Ok(success);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
