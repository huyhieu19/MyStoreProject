using Entities.StoreEntities.SewCurtains;

namespace Entities;
public class InvoiceSewCurtainEntity : BaseIdEntity
{
    public Guid CustomerId { get; set; }
    public PaymentEntity Payments { get; set; } = null!;
    public DateTime TimeFrom { get; set; } = DateTime.UtcNow;
    public DateTime TimeConpletedSewIng { get; set; } = DateTime.MaxValue;
    public DateTime TimeTo { get; set; } = DateTime.MaxValue;
    public virtual List<InvoiceSellDetailsEntity>? InvoiceSellDetails { get; set; }
}

public class InvoiceSewCurtainDetailsEntity : BaseIdEntity
{
    public Guid InvoiceSewCurtainId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public SewCurtainEntity? Merchandise { get; set; }
}
