namespace Entities
{
    public class LaundryEntity : BaseIdEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual List<PriceLaundryEntity> PriceLaundries { get; set; } = null!;
    }
}
