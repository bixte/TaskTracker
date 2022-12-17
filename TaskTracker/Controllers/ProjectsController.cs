using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskTracker.Bll.TaskTracker.BLL.Interfaces;
using TaskTracker.BLL.BusinessModels.ProjectManagers.Sort;
using TaskTracker.BLL.DTO.Project;
using TaskTracker.BLL.Interfaces;
using TaskTracker.Models.ProjectManagers.Date;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService projectService;
        private readonly string success = "успешно";
        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public ActionResult GetProjects(ProjectStatus? filterByStatus, SortBy? sortByPriority, string? date, TypeSearchDate? typeSearchDate)
        {
            try
            {
                var projectsTDO = projectService.GetProjects(filterByStatus, sortByPriority, date, typeSearchDate);
                return Ok(projectsTDO);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("{id}")]
        public ActionResult GetProjects([FromRoute] int id)
        {
            try
            {
                var projectsTDO = projectService.GetProject(id);
                return Ok(projectsTDO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult CreateProject(ProjectPostDTO projectDTO)
        {
            try
            {
                projectService.CreateProject(projectDTO);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        public ActionResult UpdateProject(ProjectUpdateDTO projectUpdateDTO)
        {
            projectService.UpdateProject(projectUpdateDTO);
            try
            {
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete]
        public ActionResult RemoveProject(int id)
        {
            try
            {
                projectService.RemoveProject(id);
                return Ok(success);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }



    }
}
