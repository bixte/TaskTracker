using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DAL.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Priority { get; set; } 

        public string? Status { get; set; }
        public int ProjectId { get; set; }

    }
}
