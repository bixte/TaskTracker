using System.Text.Json.Serialization;

namespace TaskTracker.DAL.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }
}
