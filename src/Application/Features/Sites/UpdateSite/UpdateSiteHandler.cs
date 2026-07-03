using isbwc.Application.Common;

namespace isbwc.Application.Features.Sites.UpdateSite;

public sealed class UpdateSiteHandler(IApplicationDbContext db) : IHandler<UpdateSiteCommand, SiteResponse>
{
	public async Task<Result<SiteResponse>> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
	{
		var site = await db.Sites.FindAsync([request.SiteId], cancellationToken);
		if (site is null)
		{
			return Result.Failure<SiteResponse>(Error.NotFound("Site.NotFound", $"Site '{request.SiteId}' was not found."));
		}

		site.Name = request.Name;
		site.Title = request.Title;
		site.SubTitle = request.SubTitle;
		site.Design = request.Design;
		site.Footer1 = request.Footer1;
		site.Footer2 = request.Footer2;
		site.Footer3 = request.Footer3;
		site.Footer4 = request.Footer4;
		site.MetaDescription = request.MetaDescription;
		site.MetaImagePath = request.MetaImagePath;
		site.OnAllPages = request.OnAllPages;
		site.BodyTop = request.BodyTop;
		site.BodyBottom = request.BodyBottom;
		site.ImageFileName = request.ImageFileName;
		site.FaviconUrl = request.FaviconUrl;

		await db.SaveChangesAsync(cancellationToken);

		return Result.Success(site.ToResponse());
	}
}
