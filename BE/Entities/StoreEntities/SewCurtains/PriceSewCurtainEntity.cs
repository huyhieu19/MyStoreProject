namespace Entities;

public class PriceSewCurtainEntity
{
    public Guid SewCurtainId { get; set; }
    public SewCurtainEntity SewCurtain { get; set; } = null!;
    public double PriceImport { get; set; }
    public double PriceSell { get; set; }
    public DateTime ValueDate { get; set; }
}
