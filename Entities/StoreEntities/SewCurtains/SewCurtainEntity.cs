namespace Entities.StoreEntities.SewCurtains
{
    public class SewCurtainEntity : BaseIdEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<PriceSewCurtainEntity> PriceSewCurtains { get; set; } = null!;
    }
}
