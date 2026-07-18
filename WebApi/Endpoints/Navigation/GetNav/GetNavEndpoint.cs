using isbwc.Application.Common;
using isbwc.Application.Features.Navigation;
using isbwc.Application.Features.Navigation.GetNav;
using isbwc.WebApi.Common;

namespace isbwc.WebApi.Endpoints.Navigation.GetNav;

public sealed class GetNavEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/nav", async (IHandler<GetNavQuery, IReadOnlyList<NavItemResponse>> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetNavQuery(), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetNav")
		.WithTags("Navigation");
	}
}
