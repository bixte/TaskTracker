using System.Text.Json.Serialization;

namespace TaskTracker.BLL.DTO.ProjectTask
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProjectTaskStatus
    {
        ToDo, InProgress, Done
    }
}
