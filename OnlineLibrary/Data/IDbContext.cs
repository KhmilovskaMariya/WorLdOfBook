using System.Data.Entity;

namespace Data
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
    }
}
