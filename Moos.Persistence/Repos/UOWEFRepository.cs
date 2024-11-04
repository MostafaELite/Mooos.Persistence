using Microsoft.EntityFrameworkCore;

namespace Moos.Persistence.Repos;

public class UOWEFRepository<TEntity, TId>(DbContext context) :
    ReadRepository<TEntity, TId>(context),
    IUOWRepository<TEntity, TId> where TEntity : class
{
    public virtual async Task Add(TEntity entity) => await context.AddAsync(entity);

    public virtual void Update(TEntity entity) => context.Update(entity);

    public virtual void Delete(TEntity entity) => context.Remove(entity);

    public Task Commit() => context.SaveChangesAsync();
}