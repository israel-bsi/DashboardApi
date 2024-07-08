using DashboardApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings
{
    public class ProjectStatusMap : IEntityTypeConfiguration<ProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            builder.ToTable("ProjectStatus");

            builder.HasKey(psh => new { psh.ProjectId, psh.StatsId });

            builder.HasOne(psh => psh.Project)
                .WithMany(p => p.ProjectStats)
                .HasForeignKey(psh => psh.ProjectId)
                .HasConstraintName("FK_ProjectStats_ProjectId");

            builder.HasOne(psh => psh.Status)
                .WithMany(ps => ps.ProjectStats)
                .HasForeignKey(psh => psh.StatsId)
                .HasConstraintName("FK_ProjectStats_StatsId");

            builder.Property(psh => psh.StartedAt)
                .HasColumnType("DATE");

            builder.Property(psh => psh.EndedAt)
                .HasColumnType("DATE")
                .HasDefaultValue(null);
        }
    }
}