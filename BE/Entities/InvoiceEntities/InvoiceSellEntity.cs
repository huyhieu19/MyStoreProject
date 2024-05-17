namespace Entities;

public class InvoiceSellEntity : BaseIdEntity
{
    public string InvoiceName { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public PaymentEntity Payment { get; set; } = null!;
    public DateTime ValueDate { get; set; } = DateTime.UtcNow;
    public ICollection<InvoiceSellDetailsEntity>? InvoiceSellDetails { get; set; }

    public Guid CustomerId { get; set; }
    public virtual CustomerEntity? Customer { get; set; }
}

public class InvoiceSellDetailsEntity : BaseIdEntity
{
    public Guid? InvoiceSellId { get; set; }
    public virtual InvoiceSellEntity? InvoiceSell { get; set; }


    public int Amount { get; set; } = 1;
    public Guid? MerchandiseId { get; set; }
    public string MerchandiseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double PriceImport { get; set; } = 0;
    public double PriceSell { get; set; } = 0;
}
