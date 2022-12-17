using System.ComponentModel.DataAnnotations;

namespace TaskTracker.BLL.DTO.ProjectTask
{
    public class ProjectTaskUpdateDTO
    {
        public int? Id { get; set; }
        [MinLength(3)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }

        public ProjectTaskStatus? Status { get; set; }
    }
}
