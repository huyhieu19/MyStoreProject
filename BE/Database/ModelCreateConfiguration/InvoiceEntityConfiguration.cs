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
public sealed class InvoiceSellEntityConfiguration : IEntityTypeConfiguration<InvoiceSellEntity>
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
public sealed class InvoiceSellDetailsEntityConfiguration : IEntityTypeConfiguration<InvoiceSellDetailsEntity>
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

/// <summary>
/// Configuration invoice import entity
/// </summary>
public sealed class InvoiceImportEntityConfiguration : IEntityTypeConfiguration<InvoiceImportEntity>
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

        builder.Property(p => p.ValueDate).IsRequired().HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.ImportAgentId).HasDefaultValue(null);
    }
}

/// <summary>
/// Configuration Invoice import details
/// </summary>
public sealed class InvoiceImportDetailEntityConfiguration : IEntityTypeConfiguration<InvoiceImportDetailsEntity>
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

        builder.Property(p => p.MerchandiseId).HasDefaultValue(null);

        builder.Property(p => p.MerchandiseName).HasDefaultValue(string.Empty);

        builder.Property(iid => iid.PriceImport).HasDefaultValue(null);

        builder.Property(iid => iid.PriceSell).HasDefaultValue(null);

        builder.Property(iid => iid.Amount).HasDefaultValue(1);
    }
}

/// <summary>
/// Confuguration invoice laundry entity
/// </summary>
public sealed class InvoiceLaundryEntityConfiguration : IEntityTypeConfiguration<InvoiceLaundryEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceLaundryEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.InvoiceLaundry);

        // configure keys
        builder.HasKey(p => p.Id);

        // configure relationships
        builder.HasOne(p => p.Payment)
            .WithOne(p => p.InvoiceLaundry)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceLaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InvoiceLaundryDetails)
            .WithOne(p => p.InvoiceLaundry)
            .HasForeignKey(p => p.InvoiceLaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ise => ise.Customer)
            .WithMany(c => c.InvoiceLaundries)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.InvoiceName)
            .HasMaxLength(100)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.TimeFromLaundry)
            .HasMaxLength(50)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();

        builder.Property(p => p.TimeToLaundry)
            .HasMaxLength(50)
            .HasDefaultValue((DateTime?)null);
    }
}

/// <summary>
/// Configuration invoice laundry details
/// </summary>
public sealed class InvoiceLaundryDetailsEntityConfiguration : IEntityTypeConfiguration<InvoiceLaundryDetailsEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceLaundryDetailsEntity> builder)
    {
        builder.ToTable(TableName.InvoiceLaundryDetail);

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Laundry)
            .WithMany(p => p.InvoiceLaundryDetails)
            .HasForeignKey(p => p.LaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InvoiceLaundry)
            .WithMany(p => p.InvoiceLaundryDetails)
            .HasForeignKey(p => p.InvoiceLaundryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.Name)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.Amount)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(p => p.PriceForOne)
            .HasDefaultValue(null);
    }
}

/// <summary>
/// Confuguration invoice sew curtain entity
/// </summary>
public sealed class InvoiceSewCurtainEntityConfiguration : IEntityTypeConfiguration<InvoiceSewCurtainEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceSewCurtainEntity> builder)
    {
        // configure table name
        builder.ToTable(TableName.InvoiceLaundry);

        // configure keys
        builder.HasKey(p => p.Id);

        // configure relationships
        builder.HasOne(p => p.Payment)
            .WithOne(p => p.InvoiceSewCurtain)
            .HasForeignKey<PaymentEntity>(p => p.InvoiceSewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.InvoiceSewCurtainDetails)
            .WithOne(p => p.InvoiceSewCurtain)
            .HasForeignKey(p => p.InvoiceSewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ise => ise.Customer)
            .WithMany(c => c.InvoiceSewCurtains)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Congigure property
        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.InvoiceName)
            .HasMaxLength(100)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.TimeFrom)
            .HasMaxLength(50)
            .HasDefaultValue(DateTime.UtcNow)
            .IsRequired();

        builder.Property(p => p.TimeConpletedSewIng)
            .HasMaxLength(50)
            .HasDefaultValue((DateTime?)null);

        builder.Property(p => p.TimeEnd)
            .HasMaxLength(50)
            .HasDefaultValue((DateTime?)null);
    }
}

/// <summary>
/// Configuration invoice laundry details
/// </summary>
public sealed class InvoiceSewCurtainDetailsEntityConfiguration : IEntityTypeConfiguration<InvoiceSewCurtainDetailsEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceSewCurtainDetailsEntity> builder)
    {
        builder.ToTable(TableName.InvoiceSewCurtainDetail);

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.InvoiceSewCurtain)
            .WithMany(p => p.InvoiceSewCurtainDetails)
            .HasForeignKey(p => p.InvoiceSewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.SewCurtain)
            .WithMany(p => p.InvoiceSewCurtains)
            .HasForeignKey(p => p.SewCurtainId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(p => p.Name)
            .HasMaxLength(500)
            .HasDefaultValue(string.Empty);

        builder.Property(p => p.Amount)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(p => p.PriceForOne)
            .HasDefaultValue(null);
    }
}