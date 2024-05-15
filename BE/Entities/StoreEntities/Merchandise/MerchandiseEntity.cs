namespace Entities;

public class MerchandiseEntity : BaseIdEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual List<PriceMerchandiseEntity> PriceMerchandises { get; set; } = null!;
}
