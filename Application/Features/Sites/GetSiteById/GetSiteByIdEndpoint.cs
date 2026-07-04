using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Sites.GetSiteById;

public sealed class GetSiteByIdEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/api/sites/{id:guid}", async (Guid id, IHandler<GetSiteByIdQuery, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetSiteByIdQuery(id), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetSiteById")
		.WithTags("Sites");
	}
}
