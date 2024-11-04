using Microsoft.EntityFrameworkCore;

namespace Moos.Persistence.Context;

public class ReadOnlyContext<TEntity>(Action<DbContextOptionsBuilder> optionConfig) where TEntity : class
{
    private readonly PrivateReadOnlyContext context = new (optionConfig);

    public IQueryable<TEntity> Query => context.Set<TEntity>();

    private class PrivateReadOnlyContext(Action<DbContextOptionsBuilder> customOptions) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            customOptions(optionsBuilder);
        }
    }
}