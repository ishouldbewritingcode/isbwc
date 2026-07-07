using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Sites.GetCurrentSite;

public sealed class GetCurrentSiteEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/api/site", async (IHandler<GetCurrentSiteQuery, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetCurrentSiteQuery(), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetCurrentSite")
		.WithTags("Sites");
	}
}
