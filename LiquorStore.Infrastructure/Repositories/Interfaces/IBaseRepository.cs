using System.Linq.Expressions;

namespace LiquorStore.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<TEntity,TDto> where TEntity : class
{
    Task<int> AddAsync(TDto dto);
    Task<bool> UpdateAsync(TDto dto);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TDto?> GetByIdAsync(int id);
    Task<TDto?> GetByFilterAsync(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>[] includes = null!);
    Task<List<TDto>> GetAllByFilterAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<IQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>>? filter = null);
}