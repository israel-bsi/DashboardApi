using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("user_id");
        builder.Property(x => x.Login).HasColumnName("login");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Password).HasColumnName("password");
        builder.Property(x => x.Adm).HasColumnName("adm");
    }
}