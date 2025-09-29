
using System.Linq.Expressions;

namespace Conta_Certa.DataProviders;

public interface IDataProvider<T>
{
    public Expression<Func<T, bool>> Filter { get; set; }
    
    public int GetTotalCount();
    public IEnumerable<T> GetRange<TKey>(
        int start, 
        int count, 
        Expression<Func<T, TKey>> orderBy, 
        bool orderAscending = true);
}