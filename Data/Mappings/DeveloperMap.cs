using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class DeveloperMap : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.ToTable("developers");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("developer_id");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.DevLevelId).HasColumnName("dev_level_id");
    }
}