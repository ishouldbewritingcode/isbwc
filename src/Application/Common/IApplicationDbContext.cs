using isbwc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Application.Common;

public interface IApplicationDbContext
{
	DbSet<CMSSite> Sites { get; }
	DbSet<CMSSiteUrl> SiteUrls { get; }
	DbSet<CMSPage> Pages { get; }
	DbSet<CMSPageBlock> PageBlocks { get; }
	DbSet<CMSBlock> Blocks { get; }
	DbSet<CMSItem> Items { get; }
	DbSet<CMSFile> Files { get; }
	DbSet<CMSUser> Users { get; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
