using System.ComponentModel.DataAnnotations;
using isbwc.Domain.Common;

namespace isbwc.Domain.Entities;

public class CMSUser : AuditableEntity
{
	[Key]
	public Guid UserId { get; set; }

	public Guid SiteId { get; set; }
	public string? Provider { get; set; }
	public string? NameIdentifier { get; set; }
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
	public int Salt { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Mobile { get; set; } = null!;
	public string Roles { get; set; } = null!;
	public string? TotpSecret { get; set; }

	public List<string> RoleList
	{
		get
		{
			return Roles.Split(",").ToList();
		}
	}
}
