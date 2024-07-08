using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DashboardApi.Data.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        [JsonIgnore] public IReadOnlyCollection<ProjectStatus>? ProjectStats { get; set; }
    }
}