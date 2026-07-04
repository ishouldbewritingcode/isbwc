using System.ComponentModel.DataAnnotations;
using isbwc.Domain.Common;

namespace isbwc.Domain.Entities;

public class CMSBlock : AuditableEntity
{
	[Key]
	public Guid BlockId { get; set; }
	public Guid SiteId { get; set; }
	public string? BlockType { get; set; }
	public string? Status { get; set; }
	public string? Title1 { get; set; }
	public string? Title2 { get; set; }
	public string? Data { get; set; }
	public string? Tags { get; set; }

	public List<CMSItem>? cmsItems { get; set; }
}
