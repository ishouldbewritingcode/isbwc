using isbwc.Domain.Entities;

namespace isbwc.Application.Features.Pages;

internal static class PageMapper
{
	public static PageResponse ToResponse(this CMSPage page, IReadOnlyDictionary<Guid, CMSBlock> blocks)
	{
		var pageBlocks = (page.pageBlocks ?? [])
			.Where(pb => blocks.ContainsKey(pb.BlockId))
			.OrderBy(pb => pb.Sort)
			.Select(pb => pb.ToResponse(blocks[pb.BlockId]))
			.ToList();

		return new PageResponse(
			page.PageId,
			page.ParentId,
			page.Sort,
			page.isOn,
			page.isPrivate,
			page.isHidden,
			page.Shortcut,
			page.Tags,
			page.NavTitle,
			page.Title,
			page.Summary,
			page.HeroImage,
			page.CreatedOn,
			page.UpdatedOn,
			pageBlocks);
	}

	private static PageBlockResponse ToResponse(this CMSPageBlock pageBlock, CMSBlock block) => new(
		pageBlock.PageBlockID,
		pageBlock.Sort,
		pageBlock.Position,
		pageBlock.AltTitle,
		pageBlock.AltSubtitle,
		block.ToResponse());

	private static BlockResponse ToResponse(this CMSBlock block) => new(
		block.BlockId,
		block.BlockType,
		block.Status,
		block.Title1,
		block.Title2,
		block.Data,
		block.Tags,
		(block.cmsItems ?? [])
			.OrderBy(i => i.Sort)
			.Select(i => i.ToResponse())
			.ToList());

	private static ItemResponse ToResponse(this CMSItem item) => new(
		item.ItemId,
		item.Sort,
		item.ItemType,
		item.Status,
		item.Position,
		item.Start,
		item.End,
		item.Shortcut,
		item.Title1,
		item.Title2,
		item.Data,
		item.Tags);
}
