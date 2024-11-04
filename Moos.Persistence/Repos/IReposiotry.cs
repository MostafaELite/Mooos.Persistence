using System.Linq.Expressions;

namespace Moos.Persistence.Repos;

public interface IRepository<TEntity, TId>
{
    Task<TEntity[]> GetAll();
    Task<TEntity[]> Get(IEnumerable<Expression<Func<TEntity, bool>>> filters);
    ValueTask<TEntity?> GetById(TId id);
    Task Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}

public interface IUOWRepository<TEntity, TId> : IRepository<TEntity, TId>
{
    Task Commit();
}
