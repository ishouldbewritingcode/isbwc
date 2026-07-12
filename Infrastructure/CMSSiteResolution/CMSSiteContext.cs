using isbwc.Application.Common;

namespace isbwc.Infrastructure.CMSSiteResolution;

public sealed class CMSSiteContext : ICMSSiteContext
{
	public Guid SiteId { get; set; }
}
