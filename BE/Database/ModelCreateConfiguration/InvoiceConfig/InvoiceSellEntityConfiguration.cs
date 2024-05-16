using Common.Table;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelCreateConfiguration;

public class InvoiceSellEntityConfiguration : IEntityTypeConfiguration<InvoiceSellEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceSellEntity> builder)
    {
        builder.ToTable(TableName.InvoiceSell);
        builder.HasKey(x => new { x.Id });
        builder.HasMany(p => p.InvoiceSellDetails).WithOne().HasForeignKey(p => p.InvoiceSellId).OnDelete(DeleteBehavior.ClientSetNull);
    }
}

//public class InvoiceSellDetailsEntityConfiguration : IEntityTypeConfiguration<InvoiceSellDetailsEntity>
//{
//    public void Configure(EntityTypeBuilder<InvoiceSellDetailsEntity> builder)
//    {
//        builder.ToTable(TableName.InvoiceSell);
//        builder.HasKey(x => new { x.Id });
//    }
//}
