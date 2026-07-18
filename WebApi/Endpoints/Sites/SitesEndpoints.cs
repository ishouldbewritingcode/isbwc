using isbwc.Application.Common;
using isbwc.Application.Features.Sites;
using isbwc.Application.Features.Sites.CreateSite;
using isbwc.Application.Features.Sites.DeleteSite;
using isbwc.Application.Features.Sites.GetAllSites;
using isbwc.Application.Features.Sites.GetSiteById;
using isbwc.Application.Features.Sites.UpdateSite;
using isbwc.WebApi.Common;

namespace isbwc.WebApi.Endpoints.Sites;

public sealed class SitesEndpoints : IManagerEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/sites").WithTags("Sites");

		group.MapGet("", async (IHandler<GetAllSitesQuery, IReadOnlyList<SiteResponse>> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetAllSitesQuery(), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetAllSites");

		group.MapGet("/{id:guid}", async (Guid id, IHandler<GetSiteByIdQuery, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new GetSiteByIdQuery(id), cancellationToken);
			return result.IsSuccess ? Results.Ok(result.Value) : result.Error.ToProblem();
		})
		.WithName("GetSiteById");

		group.MapPost("", async (CreateSiteCommand command, IHandler<CreateSiteCommand, SiteResponse> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(command, cancellationToken);
			return result.IsSuccess
				? Results.Created($"/api/manager/sites/{result.Value!.SiteId}", result.Value)
				: result.Error.ToProblem();
		})
		.AddEndpointFilter<ValidationFilter<CreateSiteCommand>>()
		.WithName("CreateSite");

		group.MapPut("/{id:guid}", async (Guid id, UpdateSiteRequest request, IHandler<UpdateSiteCommand, SiteResponse> handler, CancellationToken cancellationToken) =>
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
		.WithName("UpdateSite");

		group.MapDelete("/{id:guid}", async (Guid id, IHandler<DeleteSiteCommand, bool> handler, CancellationToken cancellationToken) =>
		{
			var result = await handler.Handle(new DeleteSiteCommand(id), cancellationToken);
			return result.IsSuccess ? Results.NoContent() : result.Error.ToProblem();
		})
		.WithName("DeleteSite");
	}
}
