using DashboardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Mappings;

public class ProjectMap : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projects");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("project_id");
        //builder.Property(p => p.Title).HasColumnName("title");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.AmountHours).HasColumnName("amount_hours");
        builder.Property(p => p.RequestedAt).HasColumnName("request_development");
        builder.Property(p => p.StartedAt).HasColumnName("start_development");
        builder.Property(p => p.ValidationInitiatedAt).HasColumnName("start_validation");
        builder.Property(p => p.EndedAt).HasColumnName("end_development");
        builder.Property(p => p.Customer).HasColumnName("customer");
        builder.Property(p => p.Value).HasColumnName("value");
        builder.Property(p => p.StatusId).HasColumnName("status_id");
        //builder.Property(p => p.DeveloperId).HasColumnName("developer_id");
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.PaymentId).HasColumnName("payment_id");
        builder.Property(p => p.LastUpdateAt).HasColumnName("last_update");
    }
}