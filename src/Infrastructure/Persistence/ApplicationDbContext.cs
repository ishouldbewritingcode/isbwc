using isbwc.Application.Common;
using isbwc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Infrastructure.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantContext tenantContext)
	: DbContext(options), IApplicationDbContext
{
	public DbSet<CMSSite> Sites => Set<CMSSite>();
	public DbSet<CMSSiteUrl> SiteUrls => Set<CMSSiteUrl>();
	public DbSet<CMSPage> Pages => Set<CMSPage>();
	public DbSet<CMSPageBlock> PageBlocks => Set<CMSPageBlock>();
	public DbSet<CMSBlock> Blocks => Set<CMSBlock>();
	public DbSet<CMSItem> Items => Set<CMSItem>();
	public DbSet<CMSFile> Files => Set<CMSFile>();
	public DbSet<CMSUser> Users => Set<CMSUser>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Explicit relationships using the entities' existing scalar FK properties -
		// without this, EF Core infers the FK from the navigation collections alone
		// and creates redundant shadow FK columns instead of using SiteId/PageId/BlockId.
		modelBuilder.Entity<CMSSite>()
			.HasMany(s => s.cmsSiteUrls)
			.WithOne()
			.HasForeignKey(u => u.SiteId);

		modelBuilder.Entity<CMSSite>()
			.HasMany(s => s.cmsPages)
			.WithOne()
			.HasForeignKey(p => p.SiteId);

		modelBuilder.Entity<CMSPage>()
			.HasMany(p => p.pageBlocks)
			.WithOne()
			.HasForeignKey(pb => pb.PageId);

		modelBuilder.Entity<CMSPageBlock>()
			.HasOne<CMSBlock>()
			.WithMany()
			.HasForeignKey(pb => pb.BlockId);

		modelBuilder.Entity<CMSBlock>()
			.HasMany(b => b.cmsItems)
			.WithOne()
			.HasForeignKey(i => i.BlockId);

		// CMSSite and CMSSiteUrl are intentionally NOT tenant-filtered: resolving the
		// current tenant from the request Host requires querying CMSSiteUrl across all
		// tenants, and site administration needs to list/manage every CMSSite.
		modelBuilder.Entity<CMSPage>().HasQueryFilter(e => e.SiteId == tenantContext.SiteId);
		modelBuilder.Entity<CMSBlock>().HasQueryFilter(e => e.SiteId == tenantContext.SiteId);
		modelBuilder.Entity<CMSFile>().HasQueryFilter(e => e.SiteId == tenantContext.SiteId);
		modelBuilder.Entity<CMSUser>().HasQueryFilter(e => e.SiteId == tenantContext.SiteId);

		// CMSPageBlock and CMSItem don't carry SiteId directly; they're protected
		// transitively through their Page/Block parent and are left unfiltered here.
	}
}
