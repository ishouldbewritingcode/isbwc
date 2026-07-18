using System.Reflection;
using FluentValidation;
using isbwc.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace isbwc.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly();

		foreach (var type in assembly.GetTypes().Where(t => t is { IsAbstract: false, IsInterface: false }))
		{
			var handlerInterface = type.GetInterfaces()
				.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<,>));
			if (handlerInterface is not null)
			{
				services.AddTransient(handlerInterface, type);
			}
		}

		services.AddValidatorsFromAssembly(assembly);

		return services;
	}
}
