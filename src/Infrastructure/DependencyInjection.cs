using isbwc.Application.Common;
using isbwc.Infrastructure.Persistence;
using isbwc.Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace isbwc.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<TenantContext>();
		services.AddScoped<ITenantContext>(sp => sp.GetRequiredService<TenantContext>());

		services.AddSingleton<AuditInterceptor>();

		services.AddDbContext<ApplicationDbContext>((sp, options) =>
			options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
				.AddInterceptors(sp.GetRequiredService<AuditInterceptor>()));

		services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

		services.AddHealthChecks()
			.AddDbContextCheck<ApplicationDbContext>();

		return services;
	}
}
