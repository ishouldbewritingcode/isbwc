using isbwc.Application.Common;
using isbwc.Domain.Entities;

namespace isbwc.Application.Features.Sites.CreateSite;

public sealed class CreateSiteHandler(IApplicationDbContext db) : IHandler<CreateSiteCommand, SiteResponse>
{
	public async Task<Result<SiteResponse>> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
	{
		var site = new CMSSite
		{
			SiteId = Guid.NewGuid(),
			Name = request.Name,
			Title = request.Title,
			SubTitle = request.SubTitle,
			Design = request.Design,
			Footer1 = request.Footer1,
			Footer2 = request.Footer2,
			Footer3 = request.Footer3,
			Footer4 = request.Footer4,
			MetaDescription = request.MetaDescription,
			MetaImagePath = request.MetaImagePath,
			OnAllPages = request.OnAllPages,
			BodyTop = request.BodyTop,
			BodyBottom = request.BodyBottom,
			ImageFileName = request.ImageFileName,
			FaviconUrl = request.FaviconUrl,
		};

		db.Sites.Add(site);
		await db.SaveChangesAsync(cancellationToken);

		return Result.Success(site.ToResponse());
	}
}
