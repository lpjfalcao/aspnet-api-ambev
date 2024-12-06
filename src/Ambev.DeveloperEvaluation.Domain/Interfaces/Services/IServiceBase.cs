using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        T Add(T entity);
        Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include, bool trackChanges = false);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        void Remove(T entity);
        Task Commit();
    }
}
