namespace Entities;

public class CustomerEntity : BaseUserEntity
{
    public bool IsLocateReceiveLaundry { get; set; } = false;
    public virtual ICollection<InvoiceSellEntity>? InvoiceSells { get; set; }
    public virtual ICollection<InvoiceLaundryEntity>? InvoiceLaundries { get; set; }
    public virtual ICollection<InvoiceSewCurtainEntity>? InvoiceSewCurtains { get; set; }
}
