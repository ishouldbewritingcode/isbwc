using isbwc.Application.Common;

namespace isbwc.Application.Features.Sites.DeleteSite;

public sealed class DeleteSiteHandler(IApplicationDbContext db) : IHandler<DeleteSiteCommand, bool>
{
	public async Task<Result<bool>> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
	{
		var site = await db.Sites.FindAsync([request.SiteId], cancellationToken);
		if (site is null)
		{
			return Result.Failure<bool>(Error.NotFound("Site.NotFound", $"Site '{request.SiteId}' was not found."));
		}

		db.Sites.Remove(site);
		await db.SaveChangesAsync(cancellationToken);

		return Result.Success(true);
	}
}
