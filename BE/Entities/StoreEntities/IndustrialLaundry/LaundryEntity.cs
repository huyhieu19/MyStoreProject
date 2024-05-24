namespace Entities;

public class LaundryEntity : BaseIdEntity
{
    public string Name { get; set; } = null!;
    public virtual ICollection<PriceLaundryEntity> PriceLaundries { get; set; } = null!;

    public virtual ICollection<InvoiceLaundryDetailsEntity>? InvoiceLaundryDetails { get; set; }
}