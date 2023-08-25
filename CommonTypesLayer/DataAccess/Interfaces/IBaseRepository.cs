using CommonTypesLayer.Model;
using System.Linq.Expressions;

namespace CommonTypesLayer.DataAccess.Interfaces
{

    public interface IBaseRepository<TEntity>
    where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task<TEntity> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
