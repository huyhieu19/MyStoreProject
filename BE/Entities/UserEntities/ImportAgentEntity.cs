namespace Entities;

public class ImportAgentEntity : BaseUserEntity
{
    public string? Note { get; set; }
    public string Function { get; set; } = string.Empty;
    public virtual ICollection<InvoiceImportEntity>? InvoiceImports { get; set; }
}