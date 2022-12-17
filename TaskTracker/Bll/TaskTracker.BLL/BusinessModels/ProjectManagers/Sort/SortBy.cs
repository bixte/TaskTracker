using System.Text.Json.Serialization;

namespace TaskTracker.BLL.BusinessModels.ProjectManagers.Sort
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortBy
    {
        Asc,
        Desc
    }
}
