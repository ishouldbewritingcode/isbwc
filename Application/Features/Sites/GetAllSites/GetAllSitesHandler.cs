using isbwc.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Application.Features.Sites.GetAllSites;

public sealed class GetAllSitesHandler(IApplicationDbContext db) : IHandler<GetAllSitesQuery, IReadOnlyList<SiteResponse>>
{
	public async Task<Result<IReadOnlyList<SiteResponse>>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
	{
		var sites = await db.Sites.AsNoTracking().ToListAsync(cancellationToken);
		return Result.Success<IReadOnlyList<SiteResponse>>(sites.Select(s => s.ToResponse()).ToList());
	}
}
