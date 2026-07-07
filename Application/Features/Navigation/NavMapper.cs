using isbwc.Domain.Entities;

namespace isbwc.Application.Features.Navigation;

internal static class NavMapper
{
	public static IReadOnlyList<NavItemResponse> ToNavTree(this IReadOnlyList<CMSPage> pages)
	{
		return Build(null);

		IReadOnlyList<NavItemResponse> Build(Guid? parentId) => pages
			.Where(p => p.ParentId == parentId)
			.OrderBy(p => p.Sort)
			.Select(p => new NavItemResponse(p.PageId, p.ParentId, p.Sort, p.NavTitle, p.Title, p.Shortcut, Build(p.PageId)))
			.ToList();
	}
}
