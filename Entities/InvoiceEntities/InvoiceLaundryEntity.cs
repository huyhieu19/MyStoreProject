namespace Entities;

public class InvoiceLaundryEntity : BaseIdEntity
{
    public Guid CustomerId { get; set; }
    public PaymentEntity Payments { get; set; } = null!;
    public DateTime TimeFromLaundry { get; set; } = DateTime.UtcNow;
    public DateTime TimeToLaundry { get; set; } = DateTime.UtcNow;
    public virtual List<InvoiceLaundryDetailsEntity>? InvoiceSellDetails { get; set; }
}

public class InvoiceLaundryDetailsEntity : BaseIdEntity
{
    public Guid InvoiceSellId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }
    public LaundryEntity? Laundry { get; set; }
}