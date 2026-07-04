using isbwc.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Features.Sites.UpdateSite;

public sealed class UpdateSiteEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPut("/api/sites/{id:guid}", async (Guid id, UpdateSiteRequest request, IHandler<UpdateSiteCommand, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var command = new UpdateSiteCommand(
				id,
				request.Name,
				request.Title,
				request.SubTitle,
				request.Design,
				request.Footer1,
				request.Footer2,
				request.Footer3,
				request.Footer4,
				request.MetaDescription,
				request.MetaImagePath,
				request.OnAllPages,
				request.BodyTop,
				request.BodyBottom,
				request.ImageFileName,
				request.FaviconUrl);

			var result = await handler.Handle(command, cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.AddEndpointFilter<ValidationFilter<UpdateSiteRequest>>()
		.WithName("UpdateSite")
		.WithTags("Sites");
	}
}
