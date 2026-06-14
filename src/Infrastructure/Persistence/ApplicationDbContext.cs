using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Profile.Application.Abstractions;

namespace Profile.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of the Application's persistence port.
/// Entity configurations are discovered from this assembly's
/// <c>Persistence/Configurations</c> folder.
/// </summary>
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
