namespace Entities;
public class PriceLaundryEntity : BaseIdEntity
{
    public Guid LaundryId { get; set; }
    public LaundryEntity Laundry { get; set; } = null!;
    public double Price { get; set; }
    public DateTime ValueDate { get; set; }
}
