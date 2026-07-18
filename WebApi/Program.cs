using isbwc.Application;
using isbwc.Infrastructure;
using isbwc.Infrastructure.CMSSiteResolution;
using isbwc.Infrastructure.Persistence;
using isbwc.WebApi;
using isbwc.WebApi.Common;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebApiEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	using (var scope = app.Services.CreateScope())
	{
		var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		await db.Database.MigrateAsync();
		await DbInitializer.SeedAsync(db);
	}

	app.MapOpenApi();
	app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseMiddleware<CMSSiteResolutionMiddleware>();

app.MapHealthChecks("/health");

var api = app.MapGroup("/api");
var admin = app.MapGroup("/api/admin"); // TODO: .RequireAuthorization("AdminAccess") once auth is configured — policy should accept the "Admin" or "Manager" role
var manager = app.MapGroup("/api/manager"); // TODO: .RequireAuthorization("ManagerAccess") once auth is configured — policy should require the "Manager" role

foreach (var endpoint in app.Services.GetServices<IEndpoint>())
{
	var target = endpoint switch
	{
		IManagerEndpoint => manager,
		IAdminEndpoint => admin,
		_ => api
	};
	endpoint.MapEndpoint(target);
}

app.UseDefaultFiles();
app.MapStaticAssets();

app.MapFallbackToFile("/index.html");

app.Run();
