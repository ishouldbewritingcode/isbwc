using isbwc.Application.Common;

namespace isbwc.Infrastructure.Tenancy;

public sealed class TenantContext : ITenantContext
{
	public Guid SiteId { get; set; }
}
