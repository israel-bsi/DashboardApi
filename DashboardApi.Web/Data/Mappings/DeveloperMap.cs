using DashboardApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Web.Data.Mappings;

public class DeveloperMap : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.ToTable("Developer");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasOne(d => d.Devlevel)
            .WithMany(dl => dl.Developers)
            .HasForeignKey(d => d.DevLevelId)
            .HasConstraintName("FK_Developer_DevLevel");
    }
}