using System.Text.Json.Serialization;

namespace TaskTracker.BLL.DTO.ProjectTask
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }
}
