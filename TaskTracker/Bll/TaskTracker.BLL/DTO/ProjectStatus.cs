using System.Text.Json.Serialization;

namespace TaskTracker.DAL.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProjectStatus
    {
        NotStarted, Active, Completed
    }
}
