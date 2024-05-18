namespace Entities;

/// <summary>
/// Invoice for one time import merchandise
/// </summary>
public class InvoiceImportEntity : BaseIdEntity
{
    public string InvoiceName { get; set; } = string.Empty;
    public PaymentEntity Payment { get; set; } = null!;
    public DateTime ValueDate { get; set; } = DateTime.UtcNow;
    public List<InvoiceImportDetailsEntity> InvoiceImportDetails { get; set; } = null!;

    public Guid? ImportAgentId { get; set; }
    public virtual ImportAgentEntity? ImportAgent { get; set; } = null!;
}

public class InvoiceImportDetailsEntity : BaseIdEntity
{
    public Guid InvoiceImportId { get; set; }
    public virtual InvoiceImportEntity InvoiceImport { get; set; } = null!;

    public Guid? MerchandiseId { get; set; }
    public virtual MerchandiseEntity? Merchandise { get; set; }

    public string MerchandiseName { get; set; } = string.Empty;
    public int Amount { get; set; } = 1;
    public double? PriceImport { get; set; }
    public double? PriceSell { get; set; }

}
