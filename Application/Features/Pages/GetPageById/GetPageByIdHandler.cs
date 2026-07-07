using isbwc.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Application.Features.Pages.GetPageById;

public sealed class GetPageByIdHandler(IApplicationDbContext db) : IHandler<GetPageByIdQuery, PageResponse>
{
	public async Task<Result<PageResponse>> Handle(GetPageByIdQuery request, CancellationToken cancellationToken)
	{
		var page = await db.Pages
			.AsNoTracking()
			.Include(p => p.pageBlocks)
			.FirstOrDefaultAsync(p => p.PageId == request.PageId, cancellationToken);

		if (page is null)
		{
			return Result.Failure<PageResponse>(Error.NotFound("Page.NotFound", $"Page '{request.PageId}' was not found."));
		}

		var blockIds = (page.pageBlocks ?? []).Select(pb => pb.BlockId).ToList();

		var blocks = await db.Blocks
			.AsNoTracking()
			.Include(b => b.cmsItems)
			.Where(b => blockIds.Contains(b.BlockId))
			.ToDictionaryAsync(b => b.BlockId, cancellationToken);

		return Result.Success(page.ToResponse(blocks));
	}
}
