using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Bll.TaskTracker.BLL.DTO
{
    public class ProjectTaskDTO
    {
        public int? Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Priority { get; set; }

        public TaskStatus? Status { get; set; }
        public int ProjectId { get; set; }
    }
}
