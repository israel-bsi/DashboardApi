using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class StatusProjectMap : IEntityTypeConfiguration<StatusProject>
{
    public void Configure(EntityTypeBuilder<StatusProject> builder)
    {
        builder.ToTable("status_project");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("status_id");
        builder.Property(x => x.Title).HasColumnName("title");
    }
}