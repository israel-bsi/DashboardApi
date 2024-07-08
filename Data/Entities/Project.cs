using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DashboardApi.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AmountHours { get; set; } = null!;
        public DateTime RequestedAt { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string Requester { get; set; } = null!;
        public string RequesterEmail { get; set; } = null!;
        public int PaymentStatusId { get; set; }
        public DateTime LastUpdateAt { get; set; }
        [JsonIgnore] public Customer Customer { get; set; } = null!;
        [JsonIgnore] public User User { get; set; } = null!;
        [JsonIgnore] public PaymentStatus PaymentStatus { get; set; } = null!;
        [JsonIgnore] public IList<ProjectStatus> ProjectStats { get; set; } = null!;
        [JsonIgnore] public IList<Developer> Developers { get; set; } = null!;
    }
}