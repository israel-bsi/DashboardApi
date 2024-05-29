using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class SettingsMap : IEntityTypeConfiguration<Settings>
{
    public void Configure(EntityTypeBuilder<Settings> builder)
    {
        builder.ToTable("settings");
        builder.Property(x => x.ValuePerHour).HasColumnName("valueperhour");
        builder.HasNoKey();
    }
}