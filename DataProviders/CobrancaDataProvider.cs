using Conta_Certa.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Conta_Certa.DataProviders;

public class CobrancaDataProvider : IDataProvider<Cobranca>
{
    public Expression<Func<Cobranca, bool>> Filter { get; set; } = c => true;

    private readonly AppDBContext _dbContext;
    private readonly CobrancaStatus _status;

    public CobrancaDataProvider(AppDBContext dbContext, CobrancaStatus status)
    {
        _dbContext = dbContext;
        _status = status;
    }

    public IEnumerable<Cobranca> GetRange<TKey>(int start, int count, Expression<Func<Cobranca, TKey>> orderBy, bool orderAscending = false)
    {
        var query = _dbContext.Cobrancas
            .Include(c => c.Cliente)
            .Include(c => c.ServicosCobranca)
            .Where((c) => c.Status == _status)
            .Where(Filter);

        query = orderAscending
            ? query.OrderBy(orderBy)
            : query.OrderByDescending(orderBy);

        return query.Skip(start).Take(count);
    }


    public int GetTotalCount()
    {
        return _dbContext.Cobrancas
            .Where((c) => c.Status == _status)
            .Count(Filter);
    }
}