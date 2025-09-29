using Conta_Certa.Models;
using System.Linq.Expressions;

namespace Conta_Certa.DataProviders;

public class ServicoDataProvider : IDataProvider<Servico>
{
    public Expression<Func<Servico, bool>> Filter { get; set; } = s => true;

    private AppDBContext _dbContext;
 
    public ServicoDataProvider(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Servico> GetRange<TKey>(int start, int count, Expression<Func<Servico, TKey>> orderBy, bool orderAscending = false)
    {
        var query = _dbContext.Servicos.Where(Filter);

        query = orderAscending
            ? query.OrderBy(orderBy)
            : query.OrderByDescending(orderBy);

        return query.Skip(start).Take(count);

    }

    public int GetTotalCount()
    {
        return _dbContext.Servicos.Count(Filter);
    }
}