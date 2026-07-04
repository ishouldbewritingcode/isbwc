using System.ComponentModel.DataAnnotations;
using isbwc.Domain.Common;

namespace isbwc.Domain.Entities;

public class CMSPageBlock : AuditableEntity
{
	[Key]
	public Guid PageBlockID { get; set; }
	public int Sort { get; set; } = 0;
	public Guid PageId { get; set; }
	public Guid BlockId { get; set; }
	public string? Position { get; set; }
	public string? AltTitle { get; set; }
	public string? AltSubtitle { get; set; }
}
