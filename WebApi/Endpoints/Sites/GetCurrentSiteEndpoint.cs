using isbwc.Application.Common;
using isbwc.Application.Features.Sites;
using isbwc.Application.Features.Sites.GetCurrentSite;
using isbwc.WebApi.Common;

namespace isbwc.WebApi.Endpoints.Sites;

public sealed class GetCurrentSiteEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/site", async (IHandler<GetCurrentSiteQuery, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetCurrentSiteQuery(), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetCurrentSite")
		.WithTags("Sites");
	}
}
