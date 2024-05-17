using Common.Enum;

namespace Entities;

public class PaymentDetailEntity : BaseIdEntity
{
    public Guid PaymentId { get; set; }
    public virtual PaymentEntity? Payment { get; set; }
    public Guid UserId { get; set; }
    public virtual UserEntity User { get; set; } = null!;
    public PaymentType PaymentType { get; set; } = PaymentType.Cashing;
    public DateTime PaymentTime { get; set; } = DateTime.UtcNow;
    public string? ImageUrl { get; set; }
    /// <summary>
    /// Summary amount
    /// </summary>
    public double PaymentAmount { get; set; }
}