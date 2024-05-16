namespace Entities;

/// <summary>
/// Invoice for one time import merchandise
/// </summary>
public class InvoiceImportEntity : BaseIdEntity
{
    public Guid ImportAgentId { get; set; }
    public PaymentEntity Payments { get; set; } = null!;
    public DateTime ValueDate { get; set; } = DateTime.UtcNow;
    public virtual List<MerchandiseEntity> Merchandises { get; set; } = null!;
}

public class InvoiceImportDetailsEntity : BaseIdEntity
{
    public Guid InvoiceImportId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public double PriceForOne { get; set; }
    public MerchandiseEntity? Merchandise { get; set; }
}
