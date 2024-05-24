namespace Entities;

public class MerchandiseEntity : BaseIdEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<PriceMerchandiseEntity> PriceMerchandises { get; set; } = null!;

    public virtual ICollection<InvoiceImportDetailsEntity>? InvoiceImportDetails { get; set; }

    public virtual ICollection<InvoiceSellDetailsEntity>? InvoiceSellDetails { get; set; }
}