using Microsoft.EntityFrameworkCore;

namespace Moos.Persistence.Repos;

public class SimpleEFRepository<TEntity, TId>(DbContext context) :
    ReadRepository<TEntity, TId>(context),
    IRepository<TEntity, TId>
    where TEntity : class
{
    public async Task Add(TEntity entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async void Update(TEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async void Delete(TEntity entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}