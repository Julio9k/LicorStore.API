using System.Linq.Expressions;
using LiquorStore.Infrastructure.Context;
using LiquorStore.Infrastructure.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Infrastructure.Repositories.Implementations;

public class BaseRepository<TEntity, TDto> : IBaseRepository<TEntity, TDto> where TEntity : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public async Task<int> AddAsync(TDto dto)
    {
        var entity = dto.Adapt<TEntity>();
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        var idProp = typeof(TEntity).GetProperty("Id");
        return idProp != null ? (int)idProp.GetValue(entity)! : 0;
    }

    public async Task<bool> UpdateAsync(TDto dto)
    {
        var idProp = typeof(TDto).GetProperty("Id");
        if (idProp == null) return false;

        var id = (int)idProp.GetValue(dto)!;
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public async Task<TDto?> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null ? entity.Adapt<TDto>() : default;
    }

    public async Task<TDto?> GetByFilterAsync(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>[] includes = null!)
    {
        var query = _dbSet.AsNoTracking().AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        var result = await query.FirstOrDefaultAsync();
        return result != null ? result.Adapt<TDto>() : default;
    }

    public async Task<List<TDto>> GetAllByFilterAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _dbSet.AsNoTracking().AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        var result = await query.ToListAsync();
        return result.Adapt<List<TDto>>();
    }

    public Task<IQueryable<TEntity>> GetQueryableAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _dbSet.AsNoTracking().AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        return Task.FromResult(query);
    }
}