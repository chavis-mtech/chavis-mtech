using Microsoft.Extensions.DependencyInjection;

namespace Profile.Application;

/// <summary>
/// Composition root for the Application layer. Register use-case handlers,
/// validators, and pipeline behaviours here.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register use-case services as they are added, e.g.:
        // services.AddScoped<IGetProjectsUseCase, GetProjectsUseCase>();
        return services;
    }
}
