using System.ComponentModel.DataAnnotations;
using TaskTracker.BLL.DTO.ProjectTask;

namespace TaskTracker.Bll.TaskTracker.BLL.DTO.ProjectTask
{
    public class ProjectTaskPostDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public ProjectTaskStatus? Status { get; set; }
        [Required(ErrorMessage = "требуется указать id")]
        public int ProjectId { get; set; }
    }
}
