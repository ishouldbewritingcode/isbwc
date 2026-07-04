using isbwc.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Application.Features.Sites.GetSiteById;

public sealed class GetSiteByIdHandler(IApplicationDbContext db) : IHandler<GetSiteByIdQuery, SiteResponse>
{
	public async Task<Result<SiteResponse>> Handle(GetSiteByIdQuery request, CancellationToken cancellationToken)
	{
		var site = await db.Sites.AsNoTracking().FirstOrDefaultAsync(s => s.SiteId == request.SiteId, cancellationToken);
		if (site is null)
		{
			return Result.Failure<SiteResponse>(Error.NotFound("Site.NotFound", $"Site '{request.SiteId}' was not found."));
		}

		return Result.Success(site.ToResponse());
	}
}
