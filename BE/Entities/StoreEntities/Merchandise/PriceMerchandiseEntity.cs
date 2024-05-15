namespace Entities;

public class PriceMerchandiseEntity : BaseIdEntity
{
    public Guid MerchandiseId { get; set; }
    public double PriceImport { get; set; }
    public double PriceSell { get; set; }
    public DateTime ValueDate { get; set; }
}
