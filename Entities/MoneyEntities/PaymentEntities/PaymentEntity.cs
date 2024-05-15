namespace Entities;

public class PaymentEntity : BaseIdEntity
{
    public Guid InvoiceLaundryId { get; set; }
    public bool IsPayment { get; set; } = false;
    public PaymentDetailEntity? PaymentDetail { get; set; }
}
