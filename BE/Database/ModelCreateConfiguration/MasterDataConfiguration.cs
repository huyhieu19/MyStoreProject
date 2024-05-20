using Common.Table;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelCreateConfiguration;

public sealed class PaymentEntityConfiguration : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.Payment);

        // configure keys
        builder.HasKey(p => p.Id);

        // configure relationships
        builder.HasOne(p => p.PaymentDetail)
            .WithOne(p => p.Payment)
            .HasForeignKey<PaymentDetailEntity>(p => p.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InvoiceLaundry)
            .WithOne(p => p.Payment)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceLaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InvoiceSell)
            .WithOne(p => p.Payment)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceSellId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InvoiceImport)
            .WithOne(p => p.Payment)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceImportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InvoiceSewCurtain)
            .WithOne(p => p.Payment)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceSewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.IsPayment)
            .HasDefaultValue(false)
            .IsRequired();

    }
}

public sealed class PaymentDetailEntityConfiguration : IEntityTypeConfiguration<PaymentDetailEntity>
{
    public void Configure(EntityTypeBuilder<PaymentDetailEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.PaymentDetail);

        // configure keys
        builder.HasKey(p => p.Id);

        // configure relationships
        builder.HasOne(p => p.Payment)
            .WithOne(p => p.PaymentDetail)
            .HasForeignKey<PaymentDetailEntity>(p => p.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.User)
            .WithMany(p => p.PaymentDetails)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.ImageUrl)
            .HasDefaultValue(null);

        builder.Property(p => p.PaymentAmount)
            .IsRequired();

        builder.Property(p => p.PaymentType)
            .HasColumnType("Nvarchar")
            .IsRequired();

        builder.Property(p => p.PaymentTime)
            .HasDefaultValue(DateTime.UtcNow);

    }
}


