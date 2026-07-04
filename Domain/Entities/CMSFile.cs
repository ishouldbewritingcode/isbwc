using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using isbwc.Domain.Common;

namespace isbwc.Domain.Entities;

public class CMSFile : AuditableEntity
{
	[Key]
	public Guid FileId { get; set; }

	public Guid SiteId { get; set; }
	public string Filename { get; set; } = null!;
	public string? Status { get; set; }
	public string? Text { get; set; }
	public string? Tags { get; set; }

	[NotMapped]
	public string? Temp { get; set; }
}
