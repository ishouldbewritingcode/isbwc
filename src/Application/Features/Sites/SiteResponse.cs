namespace isbwc.Application.Features.Sites;

public sealed record SiteResponse(
	Guid SiteId,
	string? Name,
	string? Title,
	string? SubTitle,
	string? Design,
	string? Footer1,
	string? Footer2,
	string? Footer3,
	string? Footer4,
	string? MetaDescription,
	string? MetaImagePath,
	string? OnAllPages,
	string? BodyTop,
	string? BodyBottom,
	string? ImageFileName,
	string? FaviconUrl,
	DateTime CreatedOn,
	DateTime? UpdatedOn);
