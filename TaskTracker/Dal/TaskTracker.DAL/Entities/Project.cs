namespace TaskTracker.DAL.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public int Priority { get; set; }
        public IEnumerable<ProjectTask> Tasks { get; set; } = null!;
    }
}
