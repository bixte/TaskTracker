using System.ComponentModel.DataAnnotations;

namespace TaskTracker.BLL.DTO.Project
{
    public class ProjectPostDTO
    {
        [MinLength(3)]
        public string? Name { get; set; }
        public ProjectStatus? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
    }
}
