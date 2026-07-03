namespace isbwc.Domain.Common;

public abstract class AuditableEntity
{
	public DateTime CreatedOn { get; set; }
	public DateTime? UpdatedOn { get; set; }
}
