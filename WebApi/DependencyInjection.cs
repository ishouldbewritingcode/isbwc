using System.Reflection;
using isbwc.WebApi.Common;

namespace isbwc.WebApi;

public static class DependencyInjection
{
	public static IServiceCollection AddWebApiEndpoints(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly();

		foreach (var type in assembly.GetTypes().Where(t => t is { IsAbstract: false, IsInterface: false }))
		{
			if (typeof(IEndpoint).IsAssignableFrom(type))
			{
				services.AddTransient(typeof(IEndpoint), type);
			}
		}

		return services;
	}
}
