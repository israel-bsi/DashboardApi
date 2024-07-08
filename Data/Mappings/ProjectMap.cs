using DashboardApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DashboardApi.Data.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.Order)
                .HasColumnType("INT")
                .HasDefaultValue(0);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(p => p.AmountHours)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(6);

            builder.Property(p => p.RequestedAt)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnType("DECIMAL(9,2)");

            builder.Property(p => p.LastUpdateAt)
                .HasColumnType("DATE")
                .HasDefaultValueSql("CURRENT_DATE");

            builder.Property(p => p.Requester)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(p => p.RequesterEmail)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_Project_User");

            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CustomerId)
                .HasConstraintName("FK_Project_Customer");

            builder.HasOne(p => p.PaymentStatus)
                .WithMany(ps => ps.Projects)
                .HasForeignKey(p => p.PaymentStatusId)
                .HasConstraintName("FK_Project_PaymentStatus");

            builder.HasMany(d => d.Developers)
                .WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectDev",
                    dev => dev
                        .HasOne<Developer>()
                        .WithMany()
                        .HasForeignKey("DevId")
                        .HasConstraintName("FK_ProjectDev_DevId"),
                    project => project
                        .HasOne<Project>()
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_ProjectDev_ProjectId"));
        }
    }
}