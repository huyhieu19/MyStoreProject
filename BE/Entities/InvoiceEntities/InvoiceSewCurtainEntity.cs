namespace Entities;

public class InvoiceSewCurtainEntity : BaseIdEntity
{
    public Guid? CustomerId { get; set; }
    public string InvoiceName { get; set; } = string.Empty;
    public PaymentEntity Payment { get; set; } = null!;
    public DateTime TimeFrom { get; set; } = DateTime.UtcNow;
    public DateTime TimeConpletedSewIng { get; set; } = DateTime.MaxValue;
    public DateTime TimeEnd { get; set; } = DateTime.MaxValue;
    public virtual List<InvoiceSewCurtainDetailsEntity>? InvoiceSewCurtainDetails { get; set; }

    public virtual CustomerEntity Customer { get; set; } = null!;
}

public class InvoiceSewCurtainDetailsEntity : BaseIdEntity
{
    public Guid InvoiceSewCurtainId { get; set; }
    public virtual InvoiceSewCurtainEntity InvoiceSewCurtain { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public double? PriceForOne { get; set; }

    public Guid? SewCurtainId { get; set; }
    public SewCurtainEntity? SewCurtain { get; set; }
}