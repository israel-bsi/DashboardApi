using DashboardApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DashboardApi.Data.Mappings;

public class StatusPaymentMap : IEntityTypeConfiguration<StatusPayment>
{
    public void Configure(EntityTypeBuilder<StatusPayment> builder)
    {
        builder.ToTable("status_payment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("payment_id");
        builder.Property(x => x.Title).HasColumnName("title");
    }
}