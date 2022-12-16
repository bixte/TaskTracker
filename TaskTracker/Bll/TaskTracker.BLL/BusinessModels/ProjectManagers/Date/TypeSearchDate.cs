using System.Text.Json.Serialization;

namespace TaskTracker.Models.ProjectManagers.Date
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeSearchDate
    {
        Start,
        End,
        StartRange,
        EndRange
    }
}
