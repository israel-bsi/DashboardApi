using System;

namespace DashboardApi.Data.Entities
{
    public class ProjectStatus
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public int StatsId { get; set; }
        public Status Status { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
    }
}