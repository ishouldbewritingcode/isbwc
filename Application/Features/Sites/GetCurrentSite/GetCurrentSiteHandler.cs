using isbwc.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Application.Features.Sites.GetCurrentSite;

public sealed class GetCurrentSiteHandler(IApplicationDbContext db, ITenantContext tenantContext) : IHandler<GetCurrentSiteQuery, SiteResponse>
{
	public async Task<Result<SiteResponse>> Handle(GetCurrentSiteQuery request, CancellationToken cancellationToken)
	{
		var site = await db.Sites.AsNoTracking().FirstOrDefaultAsync(s => s.SiteId == tenantContext.SiteId, cancellationToken);
		if (site is null)
		{
			return Result.Failure<SiteResponse>(Error.NotFound("Site.NotFound", "No site could be resolved for the current request host."));
		}

		return Result.Success(site.ToResponse());
	}
}
