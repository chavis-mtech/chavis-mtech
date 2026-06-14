using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profile.Application.Abstractions;
using Profile.Infrastructure.Persistence;

namespace Profile.Infrastructure;

/// <summary>
/// Composition root for the Infrastructure layer. Wires the PostgreSQL-backed
/// DbContext and binds it to the Application's persistence port.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
