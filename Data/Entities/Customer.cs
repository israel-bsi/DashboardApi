using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DashboardApi.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore] public IReadOnlyCollection<Project>? Projects { get; set; }
    }
}