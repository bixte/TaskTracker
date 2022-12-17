using System.ComponentModel.DataAnnotations;
using TaskTracker.DAL.Entities;

namespace TaskTracker.Models.ProjectManagers.Date
{
    public class DateSearch : ISearchByDate<Project>
    {
        private readonly string? searchDate;
        private readonly TypeSearchDate? typeSearchDate;

        public DateSearch(string? date, TypeSearchDate? typeSearchDate)
        {
            searchDate = date;
            this.typeSearchDate = typeSearchDate;
        }

        public IEnumerable<Project> Search(IEnumerable<Project> project)
        {
            if (searchDate != null && typeSearchDate.HasValue)
            {
                if (DateTime.TryParse(searchDate, out DateTime date))
                {
                    return typeSearchDate switch
                    {
                        TypeSearchDate.Start => project.Where(p => p.StartDate == date),
                        TypeSearchDate.End => project.Where(p => p.EndDate == date),
                        TypeSearchDate.StartRange => project.Where(p => p.StartDate >= date),
                        TypeSearchDate.EndRange => project.Where(p => p.EndDate <= date),
                        _ => project,
                    };
                }
                else
                    throw new ValidationException("неверный формат даты");
            }
            else
                return project;


        }
    }
}
