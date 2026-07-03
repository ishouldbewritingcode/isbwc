using Microsoft.AspNetCore.Routing;

namespace isbwc.Application.Common;

public interface IEndpoint
{
	void MapEndpoint(IEndpointRouteBuilder app);
}
