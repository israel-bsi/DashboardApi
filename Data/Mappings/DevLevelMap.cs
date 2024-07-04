using DashboardApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class DevLevelMap : IEntityTypeConfiguration<DevLevel>
{
    public void Configure(EntityTypeBuilder<DevLevel> builder)
    {
        builder.ToTable("DevLevel");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);
    }
}