using Profile.Application;
using Profile.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// --- Clean Architecture composition (dependencies flow inward) ---
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Serve the Angular SPA (published into wwwroot). In development, SpaProxy
// transparently forwards to `ng serve` (see Properties/launchSettings.json).
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// Any non-API route falls back to the SPA entry point for client-side routing.
app.MapFallbackToFile("index.html");

app.Run();
