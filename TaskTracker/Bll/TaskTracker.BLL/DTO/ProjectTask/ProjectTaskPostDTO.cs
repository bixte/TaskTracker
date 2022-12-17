using TaskTracker.BLL.DTO.ProjectTask;

namespace TaskTracker.Bll.TaskTracker.BLL.DTO.ProjectTask
{
    public class ProjectTaskPostDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public ProjectTaskStatus? Status { get; set; }
        public int ProjectId { get; set; }
    }
}
