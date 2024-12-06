using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        void Remove(T entity);
        Task Commit();
    }
}
