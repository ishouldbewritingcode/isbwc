using isbwc.Application.Common;
using isbwc.Application.Features.Pages;
using isbwc.Application.Features.Pages.GetPageById;
using isbwc.WebApi.Common;

namespace isbwc.WebApi.Endpoints.Pages.GetPageById;

public sealed class GetPageByIdEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/pages/{id:guid}", async (Guid id, IHandler<GetPageByIdQuery, PageResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetPageByIdQuery(id), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetPageById")
		.WithTags("Pages");
	}
}
