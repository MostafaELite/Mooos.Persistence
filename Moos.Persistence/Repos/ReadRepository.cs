using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Moos.Persistence.Repos;

public class ReadRepository<TEntity, TId>(DbContext context) where TEntity : class
{
    protected DbContext context = context;
    protected IQueryable<TEntity> entities = context.Set<TEntity>();

    public Task<TEntity[]> GetAll() => entities.ToArrayAsync();

    public async Task<TEntity[]> Get(IEnumerable<Expression<Func<TEntity, bool>>> filters)
    {
        foreach (var filter in filters)
            entities = entities.Where(filter);

        return await entities.ToArrayAsync();
    }

    public ValueTask<TEntity?> GetById(TId id) => context.Set<TEntity>().FindAsync(id);
}
