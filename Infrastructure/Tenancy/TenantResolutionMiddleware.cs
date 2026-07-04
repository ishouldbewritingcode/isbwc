using isbwc.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace isbwc.Infrastructure.Tenancy;

public sealed class TenantResolutionMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context, ApplicationDbContext db, TenantContext tenantContext)
	{
		var host = context.Request.Host.Host;

		var siteUrl = await db.SiteUrls
			.AsNoTracking()
			.FirstOrDefaultAsync(u => u.Url == host, context.RequestAborted);

		if (siteUrl is not null)
		{
			tenantContext.SiteId = siteUrl.SiteId;
		}

		// No match just means SiteId stays unset (Guid.Empty) - only tenant-filtered
		// entities are affected; unscoped endpoints (e.g. Sites admin API) still work.
		await next(context);
	}
}
