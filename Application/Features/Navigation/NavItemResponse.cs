namespace isbwc.Application.Features.Navigation;

public sealed record NavItemResponse(
	Guid PageId,
	Guid? ParentId,
	int Sort,
	string? NavTitle,
	string? Title,
	string? Shortcut,
	IReadOnlyList<NavItemResponse> Children);
