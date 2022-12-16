using System.ComponentModel.DataAnnotations;
using TaskTracker.DAL.Entities;

namespace TaskTracker.BLL.DTO
{
    public class ProjectDTO
    {
        [Required(ErrorMessage ="не указан id")]
        public int? Id { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [EnumDataType(typeof(ProjectStatus))]
        public ProjectStatus? Status { get; set; }
        public int? Priority { get; set; }
        public IEnumerable<ProjectTask>? Tasks { get; set; }
    }
}
