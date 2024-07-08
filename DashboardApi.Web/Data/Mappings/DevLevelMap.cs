using DashboardApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Web.Data.Mappings;

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