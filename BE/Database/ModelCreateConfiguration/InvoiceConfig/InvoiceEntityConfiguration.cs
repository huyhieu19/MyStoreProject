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
        // configure table name
        builder.ToTable(TableName.InvoiceSell);

        // configure keys
        builder.HasKey(ise => new { ise.Id });

        // configure relationships
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

        // configure properties
        builder.Property(ise => ise.InvoiceName).HasMaxLength(255).HasDefaultValue(string.Empty);

        builder.Property(ise => ise.Payment).IsRequired();

        builder.Property(ise => ise.ValueDate).HasMaxLength(20).HasDefaultValue(DateTime.UtcNow);

        builder.Property(ise => ise.CustomerName).HasMaxLength(255).HasDefaultValue(string.Empty);

        builder.Property(ise => ise.IsDeleted).HasDefaultValue(false);
        builder.Property(p => p.Description).HasDefaultValue(string.Empty);
    }
}
/// <summary>
/// configuration invoice sell detail entity before create table in database
/// 
/// </summary>
public class InvoiceSellDetailsEntityConfiguration : IEntityTypeConfiguration<InvoiceSellDetailsEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceSellDetailsEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.InvoiceSellDetail);

        // configure keys
        builder.HasKey(isde => new { isde.Id });

        // configure relationships
        builder.HasOne(isde => isde.InvoiceSell)
            .WithMany(ise => ise.InvoiceSellDetails)
            .HasForeignKey(isde => isde.InvoiceSellId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(isde => isde.Merchandise)
            .WithMany(me => me.InvoiceSellDetails)
            .HasForeignKey(isde => isde.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

        // configure properties
        builder.Property(isde => isde.Description).HasDefaultValue(string.Empty);

        builder.Property(isde => isde.IsDeleted).HasDefaultValue(false);

        builder.Property(isde => isde.MerchandiseName).HasDefaultValue(string.Empty);

        builder.Property(isde => isde.Amount).HasDefaultValue(1);

        builder.Property(isde => isde.PriceImport).HasDefaultValue(null);

        builder.Property(isde => isde.PriceSell).HasDefaultValue(null);
    }
}
