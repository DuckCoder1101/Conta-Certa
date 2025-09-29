using Conta_Certa.Models;
using System.Linq.Expressions;

namespace Conta_Certa.DataProviders;

public class ClienteDataProvider : IDataProvider<Cliente>
{
    public Expression<Func<Cliente, bool>> Filter { get; set; } = c => true;

    private AppDBContext _dbContext;

    public ClienteDataProvider(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Cliente> GetRange<TKey>(int start, int count, Expression<Func<Cliente, TKey>> orderBy, bool orderAscending = false)
    {
        var query = _dbContext.Clientes.Where(Filter);

        query = orderAscending
            ? query.OrderBy(orderBy)
            : query.OrderByDescending(orderBy);

        return query.Skip(start).Take(count);
    }

    public int GetTotalCount()
    {
        return _dbContext.Clientes.Count(Filter);
    }
}