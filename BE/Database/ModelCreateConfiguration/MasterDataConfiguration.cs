using Common.Table;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelCreateConfiguration;

#region Payment
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
#endregion Payment

#region Laundry
/// <summary>
/// Configuration Laundry Entity
/// </summary>
public sealed class LaundryEntityConfiguration : IEntityTypeConfiguration<LaundryEntity>
{
    public void Configure(EntityTypeBuilder<LaundryEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.Laundry);

        // configure keys
        builder.HasKey(p => p.Id);

        // configure relationships
        // configure relationships
        builder.HasMany(p => p.PriceLaundries)
            .WithOne(p => p.Laundry)
            .HasForeignKey(p => p.LaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InvoiceLaundryDetails)
            .WithOne(p => p.Laundry)
            .HasForeignKey(p => p.LaundryId)
            .OnDelete(DeleteBehavior.Restrict);


        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.Name)
            .IsRequired();
    }
}

/// <summary>
/// Configuration Price Launry Entity
/// </summary>
public sealed class PriceLaundryEntityConfiguration : IEntityTypeConfiguration<PriceLaundryEntity>
{
    public void Configure(EntityTypeBuilder<PriceLaundryEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.PriceLaundry);

        // configure keys
        builder.HasKey(p => p.Id);

        // configure relationships
        builder.HasOne(p => p.Laundry)
            .WithMany(p => p.PriceLaundries)
            .HasForeignKey(p => p.LaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.ValueDate)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasDefaultValue(0)
            .IsRequired();
    }
}
#endregion

#region Merchandise
public sealed class MerchandiseEntiryConfiguration : IEntityTypeConfiguration<MerchandiseEntity>
{
    public void Configure(EntityTypeBuilder<MerchandiseEntity> builder)
    {
        builder.ToTable(TableName.Merchandise);
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.PriceMerchandises)
            .WithOne(p => p.Merchandise)
            .HasForeignKey(p => p.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InvoiceSellDetails)
            .WithOne(p => p.Merchandise)
            .HasForeignKey(p => p.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InvoiceImportDetails)
            .WithOne(p => p.Merchandise)
            .HasForeignKey(p => p.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.Name)
            .HasDefaultValue(string.Empty);
    }
}

public sealed class PriceMerchandiseEntityConfiguration : IEntityTypeConfiguration<PriceMerchandiseEntity>
{
    public void Configure(EntityTypeBuilder<PriceMerchandiseEntity> builder)
    {
        builder.ToTable(TableName.PriceMerchandise);
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Merchandise)
            .WithMany(p => p.PriceMerchandises)
            .HasForeignKey(p => p.MerchandiseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.ValueDate)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();

        builder.Property(p => p.PriceImport)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(p => p.PriceSell)
            .HasDefaultValue(0)
            .IsRequired();
    }
}
#endregion

#region Sew Curtains
public sealed class SewCurtainEntityConfiguration : IEntityTypeConfiguration<SewCurtainEntity>
{
    public void Configure(EntityTypeBuilder<SewCurtainEntity> builder)
    {
        builder.ToTable(TableName.SewCurtain);
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.PriceSewCurtains)
            .WithOne(p => p.SewCurtain)
            .HasForeignKey(p => p.SewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InvoiceSewCurtains)
            .WithOne(p => p.SewCurtain)
            .HasForeignKey(p => p.SewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.Name)
            .HasDefaultValue(string.Empty);
    }
}

public sealed class PriceSewCurtainEntityConfiguration : IEntityTypeConfiguration<PriceSewCurtainEntity>
{
    public void Configure(EntityTypeBuilder<PriceSewCurtainEntity> builder)
    {
        builder.ToTable(TableName.PriceSewCurtain);
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.SewCurtain)
            .WithMany(p => p.PriceSewCurtains)
            .HasForeignKey(p => p.SewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.ValueDate)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();

        builder.Property(p => p.PriceImport)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(p => p.PriceSell)
            .HasDefaultValue(0)
            .IsRequired();
    }
}
#endregion