namespace Entities
{
    public class BaseIdEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}