using System.ComponentModel.DataAnnotations;
using isbwc.Domain.Common;

namespace isbwc.Domain.Entities;

public class CMSSiteUrl : AuditableEntity
{
	[Key]
	public Guid SiteUrlId { get; set; }

	public Guid SiteId { get; set; }
	public string Url { get; set; } = null!;
	public bool Primary { get; set; }
}
