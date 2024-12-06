using Ambev.DeveloperEvaluation.Domain.Interfaces.Repositories;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public T Add(T entity)
        {
            this.repository.Create(entity);

            return entity;
        }

        public async Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.repository.GetListByCondition(expression);
        }

        public async Task<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.repository.GetByCondition(expression);
        }

        public async Task<T> GetByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include, bool trackChanges = false)
        {
            return await this.repository.GetByCondition(expression, include);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return await this.repository.GetAll(includes);
        }

        public void Remove(T entity)
        {
            this.repository.Remove(entity);
        }

        public void Update(T entity)
        {
            this.repository.Update(entity);
        }

        public async Task Commit()
        {
            await this.repository.Commit();
        }
    }
}
