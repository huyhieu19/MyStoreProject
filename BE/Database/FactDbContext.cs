using Database.ModelCreateConfiguration;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class FactDbContext : IdentityDbContext<UserEntity>
{
    public FactDbContext(DbContextOptions<FactDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
        // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
        // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName!.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
            // User
            // Identity Role
            //builder.ApplyConfiguration(new RoleConfiguration());

            builder.ApplyConfiguration(new InvoiceSellEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceSellDetailsEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceImportDetailEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceImportEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceLaundryDetailsEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceLaundryDetailsEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceSewCurtainDetailsEntityConfiguration());
            builder.ApplyConfiguration(new InvoiceSewCurtainEntityConfiguration());

            builder.ApplyConfiguration(new PaymentEntityConfiguration());
            builder.ApplyConfiguration(new PaymentDetailEntityConfiguration());

            builder.ApplyConfiguration(new LaundryEntityConfiguration());
            builder.ApplyConfiguration(new PriceLaundryEntityConfiguration());
            builder.ApplyConfiguration(new MerchandiseEntiryConfiguration());
            builder.ApplyConfiguration(new PriceMerchandiseEntityConfiguration());
            builder.ApplyConfiguration(new SewCurtainEntityConfiguration());
            builder.ApplyConfiguration(new PriceSewCurtainEntityConfiguration());
        }
    }

    #region DB set

    // Person
    public DbSet<ImportAgentEntity> ImportAgents { get; set; } = null!;

    public DbSet<CustomerEntity> Customers { get; set; } = null!;

    // Invoice
    public DbSet<InvoiceImportEntity> InvoiceImports { get; set; } = null!;

    public DbSet<InvoiceLaundryEntity> InvoiceLaundries { get; set; } = null!;
    public DbSet<InvoiceSellEntity> InvoiceSells { get; set; } = null!;
    public DbSet<InvoiceSewCurtainEntity> InvoiceSewCurtains { get; set; } = null!;

    // Payment
    public DbSet<PaymentEntity> Payments { get; set; } = null!;

    public DbSet<PaymentDetailEntity> PaymentDetails { get; set; } = null!;

    // Merchandise
    public DbSet<MerchandiseEntity> Merchandises { get; set; } = null!;

    public DbSet<PriceMerchandiseEntity> PriceMerchandises { get; set; } = null!;
    public DbSet<LaundryEntity> Laundries { get; set; } = null!;
    public DbSet<PriceLaundryEntity> PriceLaundrys { get; set; } = null!;
    public DbSet<SewCurtainEntity> SewCurtains { get; set; } = null!;
    public DbSet<PriceSewCurtainEntity> PriceSewCurtain { get; set; } = null!;

    #endregion DB set
}