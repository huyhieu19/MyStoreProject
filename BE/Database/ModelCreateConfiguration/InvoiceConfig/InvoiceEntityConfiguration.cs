using Common.Table;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelCreateConfiguration;

/// <summary>
/// Configuration invoice sell entity before create table in database
/// n invoice sell - 1 customer
/// 1 inovice sell - 1 payment
/// 1 inovice sell - n invoice sell detail
/// </summary>
public class InvoiceSellEntityConfiguration : IEntityTypeConfiguration<InvoiceSellEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceSellEntity> builder)
    {
        builder.ToTable(TableName.InvoiceSell);
        builder.HasKey(ise => new { ise.Id });
        builder.HasMany(ise => ise.InvoiceSellDetails)
            .WithOne(isde => isde.InvoiceSell)
            .HasForeignKey(p => p.InvoiceSellId)
            .OnDelete(DeleteBehavior.Restrict); // 1 inovice sell - n invoice sell detail
        builder.HasOne(ise => ise.Customer)
            .WithMany(c => c.InvoiceSells)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict); // n invoice sell - 1 customer
        builder.HasOne(ise => ise.Payment)
            .WithOne(p => p.InvoiceSell)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceSellId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(ise => ise.IsDeleted).HasDefaultValue(false);
    }
}
/// <summary>
/// configuration invoice sell detail entity before create table in database
/// n inv
/// </summary>
public class InvoiceSellDetailsEntityConfiguration : IEntityTypeConfiguration<InvoiceSellDetailsEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceSellDetailsEntity> builder)
    {
        builder.ToTable(TableName.InvoiceSellDetail);
        builder.HasKey(isde => new { isde.Id });
        builder.HasOne(isde => isde.InvoiceSell)
            .WithMany(ise => ise.InvoiceSellDetails)
            .HasForeignKey(isde => isde.InvoiceSellId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(ise => ise.IsDeleted).HasDefaultValue(false);
    }
}
