using Common.Table;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelCreateConfigurationl;

public class InvoiceImportEntityConfiguration : IEntityTypeConfiguration<InvoiceImportEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceImportEntity> builder)
    {
        builder.ToTable(TableName.InvoiceImport);
        builder.HasKey(iie => iie.Id);
        builder.HasMany(iie => iie.InvoiceImportDetails)
            .WithOne(iide => iide.InvoiceImport)
            .HasForeignKey(p => p.InvoiceImportId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(ise => ise.IsDeleted).HasDefaultValue(false);
    }
}
