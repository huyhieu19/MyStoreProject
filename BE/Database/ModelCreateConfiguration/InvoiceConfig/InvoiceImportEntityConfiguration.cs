using Common.Table;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelCreateConfigurationl;

public class InvoiceImportEntityConfiguration : IEntityTypeConfiguration<InvoiceImportEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceImportEntity> builder)
    {
        // Configure table name
        builder.ToTable(TableName.InvoiceImport);

        // Configure keys
        builder.HasKey(iie => iie.Id);

        // Configure relationships
        builder.HasMany(iie => iie.InvoiceImportDetails)
            .WithOne(iide => iide.InvoiceImport)
            .HasForeignKey(p => p.InvoiceImportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(iie => iie.Payment)
            .WithOne(pe => pe.InvoiceImport)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceImportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(iie => iie.ImportAgent)
            .WithMany(iae => iae.InvoiceImports)
            .HasForeignKey(iie => iie.ImportAgentId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        // Configure properties
        builder.Property(iie => iie.IsDeleted).HasDefaultValue(false);

        builder.Property(p => p.Description).HasDefaultValue(string.Empty);

        builder.Property(p => p.InvoiceName).HasDefaultValue(string.Empty);

        builder.Property(p => p.Payment).IsRequired();

        builder.Property(p => p.ValueDate).IsRequired().HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.InvoiceImportDetails).IsRequired();

        builder.Property(p => p.ImportAgentId).HasDefaultValue(null);

        builder.Property(p => p.ImportAgent).HasDefaultValue(null);
    }
}

public class InvoiceImportDetailEntityConfiguration : IEntityTypeConfiguration<InvoiceImportDetailsEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceImportDetailsEntity> builder)
    {
        // Configure table name
        builder.ToTable(TableName.InvoiceImportDetail);

        // Configure keys
        builder.HasKey(iide => iide.Id);

        // Configure relationships
        builder.HasOne(iide => iide.InvoiceImport)
            .WithMany(iie => iie.InvoiceImportDetails)
            .HasForeignKey(iide => iide.InvoiceImportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(iide => iide.Merchandise)
            .WithMany(me => me.InvoiceImportDetails)
            .HasForeignKey(iide => iide.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure properties
        builder.Property(iid => iid.IsDeleted).HasDefaultValue(false);

        builder.Property(p => p.Description).HasDefaultValue(string.Empty);

        builder.Property(p => p.InvoiceImportId).IsRequired();

        builder.Property(p => p.InvoiceImport).IsRequired();

        builder.Property(p => p.MerchandiseId).HasDefaultValue(null);

        builder.Property(p => p.Merchandise).HasDefaultValue(null);

        builder.Property(p => p.MerchandiseName).HasDefaultValue(string.Empty);

        builder.Property(iid => iid.PriceImport).HasDefaultValue(null);

        builder.Property(iid => iid.PriceSell).HasDefaultValue(null);

        builder.Property(iid => iid.Amount).HasDefaultValue(1);

    }
}
