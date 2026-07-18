using isbwc.Application.Common;

namespace isbwc.WebApi.Common;

public static class ResultExtensions
{
	public static IResult ToProblem(this Error error) => error.Type switch
	{
		ErrorType.NotFound => Results.NotFound(new { error.Code, error.Message }),
		ErrorType.Validation => Results.BadRequest(new { error.Code, error.Message }),
		ErrorType.Conflict => Results.Conflict(new { error.Code, error.Message }),
		_ => Results.Problem(detail: error.Message, statusCode: StatusCodes.Status500InternalServerError),
	};
}
