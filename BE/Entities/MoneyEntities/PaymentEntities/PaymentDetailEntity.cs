using Common.Enum;

namespace Entities;

public class PaymentDetailEntity
{
    public Guid PaymentId { get; set; }
    public Guid UserId { get; set; }
    public PaymentType PaymentType { get; set; } = PaymentType.Cashing;
    public DateTime PaymentTime { get; set; } = DateTime.UtcNow;
    public string? ImageUrl { get; set; }
    /// <summary>
    /// Summary amount
    /// </summary>
    public double PaymentAmount { get; set; }

}