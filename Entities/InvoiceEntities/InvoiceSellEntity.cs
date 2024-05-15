namespace Entities;

public class InvoiceSellEntity : BaseIdEntity
{
    public Guid CustomerId { get; set; }
    public PaymentEntity Payments { get; set; } = null!;
    public DateTime ValueDate { get; set; } = DateTime.UtcNow;
    public virtual List<InvoiceSellDetailsEntity>? InvoiceSellDetails { get; set; }
}

public class InvoiceSellDetailsEntity : BaseIdEntity
{
    public Guid InvoiceSellId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }
    public MerchandiseEntity? Merchandise { get; set; }
}
