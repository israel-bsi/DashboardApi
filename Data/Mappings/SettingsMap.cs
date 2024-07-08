using DashboardApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings
{
    public class SettingsMap : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.ToTable("Settings");

            builder.Property(x => x.ValuePerHour)
                .HasColumnType("DECIMAL(9,2)");

            builder.HasNoKey();
        }
    }
}