using isbwc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Infrastructure.Persistence;

public static class DbInitializer
{
	public static async Task SeedAsync(ApplicationDbContext db, CancellationToken cancellationToken = default)
	{
		if (await db.Sites.IgnoreQueryFilters().AnyAsync(cancellationToken))
		{
			return;
		}

		var site = new CMSSite
		{
			SiteId = Guid.NewGuid(),
			Name = "Default Site",
			Title = "Welcome",
		};

		db.Sites.Add(site);
		db.SiteUrls.Add(new CMSSiteUrl
		{
			SiteUrlId = Guid.NewGuid(),
			SiteId = site.SiteId,
			Url = "localhost",
			Primary = true,
		});

		await db.SaveChangesAsync(cancellationToken);
	}
}
