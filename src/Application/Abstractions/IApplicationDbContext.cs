namespace Profile.Application.Abstractions;

/// <summary>
/// Persistence port owned by the Application layer. Infrastructure provides the
/// EF Core implementation; use cases depend only on this abstraction.
/// Expose aggregate roots as <c>DbSet&lt;T&gt;</c> properties here as they are added.
/// </summary>
public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
