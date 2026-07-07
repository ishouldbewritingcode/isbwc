using isbwc.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Application.Features.Navigation.GetNav;

public sealed class GetNavHandler(IApplicationDbContext db) : IHandler<GetNavQuery, IReadOnlyList<NavItemResponse>>
{
	public async Task<Result<IReadOnlyList<NavItemResponse>>> Handle(GetNavQuery request, CancellationToken cancellationToken)
	{
		// Nav is public-facing: only published, non-hidden, non-private pages are exposed
		// (there's no auth layer yet to gate access to private pages beyond this).
		var pages = await db.Pages
			.AsNoTracking()
			.Where(p => p.isOn && !p.isHidden && !p.isPrivate)
			.ToListAsync(cancellationToken);

		return Result.Success(pages.ToNavTree());
	}
}
