using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Sites.CreateSite;

public sealed class CreateSiteEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("/api/sites", async (CreateSiteCommand command, IHandler<CreateSiteCommand, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(command, cancellationToken);
			return result.IsSuccess
				? Results.Created($"/api/sites/{result.Value!.SiteId}", result.Value)
				: result.Error.ToProblem();
		})
		.AddEndpointFilter<ValidationFilter<CreateSiteCommand>>()
		.WithName("CreateSite")
		.WithTags("Sites");
	}
}
