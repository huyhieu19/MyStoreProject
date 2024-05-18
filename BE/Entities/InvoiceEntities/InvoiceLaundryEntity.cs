namespace Entities;

public class InvoiceLaundryEntity : BaseIdEntity
{
    public Guid CustomerId { get; set; }
    public string InvoiceName { get; set; } = string.Empty;
    public PaymentEntity Payments { get; set; } = null!;
    public DateTime TimeFromLaundry { get; set; } = DateTime.UtcNow;
    public DateTime TimeToLaundry { get; set; } = DateTime.MaxValue;
    public virtual List<InvoiceLaundryDetailsEntity>? InvoiceSellDetails { get; set; }
}

public class InvoiceLaundryDetailsEntity : BaseIdEntity
{
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public double? PriceForOne { get; set; }

    public Guid? LaundryId { get; set; }
    public virtual LaundryEntity? Laundry { get; set; }

    public Guid InvoiceLaundryId { get; set; }
    public virtual InvoiceLaundryEntity? InvoiceLaundry { get; set; }
}