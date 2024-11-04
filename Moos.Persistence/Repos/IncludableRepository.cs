using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Moos.Persistence.Repos;

public class IncludableRepository<TEntity, TId, TUseCase>(DbContext context) :
    SimpleEFRepository<TEntity, TId>(context), IRepository<TEntity, TId>
    where TEntity : class

{
    private readonly IncludesProvider? includesProvider;

    public void With(IEnumerable<Expression<Func<TEntity, object>>> navigationProperties)
    {
        foreach (var include in navigationProperties)
            entities = entities.Include(include);
    }

    public void With(IEnumerable<string> navigationProperties)
    {
        foreach (var include in navigationProperties)
            entities = entities.Include(include);
    }

    public void ForUseCase(TUseCase useCase)
    {
        if (includesProvider is null)
            throw new ArgumentNullException(nameof(includesProvider));

        var includes = includesProvider.GetIncludes();
        With(includes);
    }
}