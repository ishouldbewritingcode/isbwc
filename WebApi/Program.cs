using isbwc.Application;
using isbwc.Application.Common;
using isbwc.Infrastructure;
using isbwc.Infrastructure.CMSSiteResolution;
using isbwc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

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

foreach (var endpoint in app.Services.GetServices<IEndpoint>())
{
	endpoint.MapEndpoint(app);
}

app.UseDefaultFiles();
app.MapStaticAssets();

app.MapFallbackToFile("/index.html");

app.Run();
