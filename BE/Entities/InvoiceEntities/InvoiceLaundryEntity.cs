namespace Entities;

public class InvoiceLaundryEntity : BaseIdEntity
{
    public Guid CustomerId { get; set; }
    public virtual PaymentEntity Payments { get; set; } = null!;
    public DateTime TimeFromLaundry { get; set; } = DateTime.UtcNow;
    public DateTime TimeToLaundry { get; set; } = DateTime.MaxValue;
    public virtual List<InvoiceLaundryDetailsEntity>? InvoiceSellDetails { get; set; }
}

public class InvoiceLaundryDetailsEntity : BaseIdEntity
{
    public Guid InvoiceSellId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public LaundryEntity? Laundry { get; set; }
    public virtual InvoiceLaundryEntity? InvoiceLaundry { get; set; }
}