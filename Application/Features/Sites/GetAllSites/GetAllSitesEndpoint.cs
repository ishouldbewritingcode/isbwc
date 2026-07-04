using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Sites.GetAllSites;

public sealed class GetAllSitesEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/api/sites", async (IHandler<GetAllSitesQuery, IReadOnlyList<SiteResponse>> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetAllSitesQuery(), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetAllSites")
		.WithTags("Sites");
	}
}
