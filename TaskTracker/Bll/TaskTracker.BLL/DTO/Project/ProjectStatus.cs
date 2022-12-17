using System.Text.Json.Serialization;

namespace TaskTracker.BLL.DTO.Project
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProjectStatus
    {
        NotStarted, Active, Completed
    }
}
