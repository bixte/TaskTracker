namespace TaskTracker.BLL.DTO.Project
{
    public class ProjectUpdateDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public ProjectStatus? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
    }
}
