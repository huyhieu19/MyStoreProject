namespace Entities;

public class PriceMerchandiseEntity : BaseIdEntity
{
    public Guid MerchandiseId { get; set; }
    public virtual MerchandiseEntity Merchandise { get; set; } = null!;
    public double PriceImport { get; set; }
    public double PriceSell { get; set; }
    public DateTime ValueDate { get; set; }
}