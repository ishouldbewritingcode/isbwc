using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Sites.DeleteSite;

public sealed class DeleteSiteEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapDelete("/api/sites/{id:guid}", async (Guid id, IHandler<DeleteSiteCommand, bool> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new DeleteSiteCommand(id), cancellationToken);
			return result.IsSuccess ? Results.NoContent() : result.Error.ToProblem();
		})
		.WithName("DeleteSite")
		.WithTags("Sites");
	}
}
