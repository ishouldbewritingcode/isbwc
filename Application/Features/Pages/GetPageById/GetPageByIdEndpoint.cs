using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Pages.GetPageById;

public sealed class GetPageByIdEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/api/pages/{id:guid}", async (Guid id, IHandler<GetPageByIdQuery, PageResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetPageByIdQuery(id), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetPageById")
		.WithTags("Pages");
	}
}
