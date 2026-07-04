using isbwc.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace isbwc.Infrastructure.Persistence;

public sealed class AuditInterceptor : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		ApplyAuditInfo(eventData.Context);
		return base.SavingChanges(eventData, result);
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		ApplyAuditInfo(eventData.Context);
		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private static void ApplyAuditInfo(DbContext? context)
	{
		if (context is null)
		{
			return;
		}

		var now = DateTime.UtcNow;

		foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedOn = now;
			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Entity.UpdatedOn = now;
			}
		}
	}
}
