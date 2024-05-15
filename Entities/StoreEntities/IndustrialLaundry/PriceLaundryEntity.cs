namespace Entities;
public class PriceLaundryEntity : BaseIdEntity
{
    public Guid LaundryId { get; set; }
    public double Price { get; set; }
    public DateTime ValueDate { get; set; }
}
