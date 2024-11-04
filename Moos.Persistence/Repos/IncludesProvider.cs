namespace Moos.Persistence.Repos;

public interface IncludesProvider
{
    IEnumerable<string> GetIncludes();
}