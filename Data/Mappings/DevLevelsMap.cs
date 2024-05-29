using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class DevLevelsMap : IEntityTypeConfiguration<DevLevels>
{
    public void Configure(EntityTypeBuilder<DevLevels> builder)
    {
        builder.ToTable("dev_levels");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("dev_level_id");
        builder.Property(p => p.Title).HasColumnName("title");
    }
}