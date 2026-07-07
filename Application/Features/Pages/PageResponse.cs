namespace isbwc.Application.Features.Pages;

public sealed record PageResponse(
	Guid PageId,
	Guid? ParentId,
	int Sort,
	bool IsOn,
	bool IsPrivate,
	bool IsHidden,
	string? Shortcut,
	string? Tags,
	string? NavTitle,
	string? Title,
	string? Summary,
	string? HeroImage,
	DateTime CreatedOn,
	DateTime? UpdatedOn,
	IReadOnlyList<PageBlockResponse> Blocks);

public sealed record PageBlockResponse(
	Guid PageBlockId,
	int Sort,
	string? Position,
	string? AltTitle,
	string? AltSubtitle,
	BlockResponse Block);

public sealed record BlockResponse(
	Guid BlockId,
	string? BlockType,
	string? Status,
	string? Title1,
	string? Title2,
	string? Data,
	string? Tags,
	IReadOnlyList<ItemResponse> Items);

public sealed record ItemResponse(
	Guid ItemId,
	int Sort,
	string? ItemType,
	string? Status,
	string? Position,
	DateTime? Start,
	DateTime? End,
	string? Shortcut,
	string? Title1,
	string? Title2,
	string? Data,
	string? Tags);
