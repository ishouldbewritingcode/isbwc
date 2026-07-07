using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Navigation.GetNav;

public sealed class GetNavEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/api/nav", async (IHandler<GetNavQuery, IReadOnlyList<NavItemResponse>> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetNavQuery(), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetNav")
		.WithTags("Navigation");
	}
}
