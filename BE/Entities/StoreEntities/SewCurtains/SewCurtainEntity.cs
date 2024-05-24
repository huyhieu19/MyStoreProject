namespace Entities;

public class SewCurtainEntity : BaseIdEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<PriceSewCurtainEntity> PriceSewCurtains { get; set; } = null!;
    public virtual ICollection<InvoiceSewCurtainDetailsEntity>? InvoiceSewCurtains { get; set; }
}