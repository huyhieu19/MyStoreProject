namespace Entities;
public class BaseUserEntity : BaseIdEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}
