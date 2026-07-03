using isbwc.Domain.Entities;

namespace isbwc.Application.Features.Sites;

internal static class SiteMapper
{
	public static SiteResponse ToResponse(this CMSSite site) => new(
		site.SiteId,
		site.Name,
		site.Title,
		site.SubTitle,
		site.Design,
		site.Footer1,
		site.Footer2,
		site.Footer3,
		site.Footer4,
		site.MetaDescription,
		site.MetaImagePath,
		site.OnAllPages,
		site.BodyTop,
		site.BodyBottom,
		site.ImageFileName,
		site.FaviconUrl,
		site.CreatedOn,
		site.UpdatedOn);
}
