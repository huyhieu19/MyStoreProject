namespace Entities;

public class PaymentEntity : BaseIdEntity
{
    public Guid? InvoiceLaundryId { get; set; }
    public virtual InvoiceLaundryEntity? InvoiceLaundry { get; set; }
    public Guid? InvoiceSellId { get; set; }
    public virtual InvoiceSellEntity? InvoiceSell { get; set; }
    public Guid? InvoiceImportId { get; set; }
    public virtual InvoiceImportEntity? InvoiceImport { get; set; }
    public Guid? InvoiceSewCurtainId { get; set; }
    public virtual InvoiceSewCurtainEntity? InvoiceSewCurtain { get; set; }

    public bool IsPayment { get; set; } = false;
    public Guid? PaymentDetailId { get; set; }
    public virtual PaymentDetailEntity? PaymentDetail { get; set; }
}
