namespace Entities;

public class InvoiceSellEntity : BaseIdEntity
{
    public string InvoiceName { get; set; } = string.Empty;
    public PaymentEntity Payment { get; set; } = null!;
    public DateTime ValueDate { get; set; } = DateTime.UtcNow;
    public ICollection<InvoiceSellDetailsEntity>? InvoiceSellDetails { get; set; }

    public Guid? CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public virtual CustomerEntity? Customer { get; set; }
}

public class InvoiceSellDetailsEntity : BaseIdEntity
{
    public Guid? InvoiceSellId { get; set; }
    public virtual InvoiceSellEntity? InvoiceSell { get; set; }

    public Guid? MerchandiseId { get; set; }
    public virtual MerchandiseEntity? Merchandise { get; set; }

    public string MerchandiseName { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public double? PriceImport { get; set; }
    public double? PriceSell { get; set; }
}
