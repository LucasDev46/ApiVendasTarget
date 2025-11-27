
using System.Linq.Expressions;

namespace VendasBusiness.Interface.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectByQuery(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        Task Commit();
    }
}
