using TaskTracker.DAL.Entities;

namespace TaskTracker.Models.ProjectManagers.Date
{
    public class ProjectDateSearch : ISearchByDate<Project>
    {
        private readonly string? searchDate;
        private readonly TypeSearchDate typeSearchDate;

        public ProjectDateSearch(string date, TypeSearchDate typeSearchDate)
        {
            searchDate = date;
            this.typeSearchDate = typeSearchDate;
        }

        public IQueryable<Project> Search(IQueryable<Project> projects)
        {
            if (DateTime.TryParse(searchDate, out DateTime date))
            {
               return typeSearchDate switch
                {
                    TypeSearchDate.Start => projects.Where(p => p.StartDate == date),
                    TypeSearchDate.End => projects.Where(p => p.EndDate == date),
                    TypeSearchDate.StartRange => projects.Where(p => p.StartDate >= date),
                    TypeSearchDate.EndRange => projects.Where(p => p.EndDate <= date),
                    _ => projects,
                };
            }
            else
                throw new Exception("неверный формат даты");
        }
    }
}
