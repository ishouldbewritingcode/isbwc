using FluentValidation;

namespace isbwc.WebApi.Common;

public sealed class ValidationFilter<TCommand> : IEndpointFilter
{
	public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
	{
		var command = context.Arguments.OfType<TCommand>().FirstOrDefault();
		if (command is null)
		{
			return await next(context);
		}

		var validator = context.HttpContext.RequestServices.GetService<IValidator<TCommand>>();
		if (validator is null)
		{
			return await next(context);
		}

		var validationResult = await validator.ValidateAsync(command, context.HttpContext.RequestAborted);
		if (!validationResult.IsValid)
		{
			return Results.ValidationProblem(validationResult.ToDictionary());
		}

		return await next(context);
	}
}
