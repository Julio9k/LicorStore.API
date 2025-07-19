using System.Linq.Expressions;
using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Context;
using LiquorStore.Infrastructure.Entities;
using LiquorStore.Infrastructure.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Infrastructure.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(UserDto dto)
    {
        var entity = dto.Adapt<User>();
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(UserDto dto)
    {
        var entity = await _context.Users.FindAsync(dto.Id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(Expression<Func<User, bool>> filter)
    {
        return await _context.Users.AnyAsync(filter);
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var entity = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == id);
        return entity != null ? entity.Adapt<UserDto>() : default;
    }

    public async Task<UserDto?> GetByFilterAsync(Expression<Func<User, bool>>? filter = null)
    {
        var query = _context.Users.Include(u => u.Role).AsNoTracking().AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        var result = await query.FirstOrDefaultAsync();
        return result != null ? result.Adapt<UserDto>() : default;
    }

    public Task<IQueryable<User>> GetQueryableAsync(Expression<Func<User, bool>>? filter = null)
    {
        var query = _context.Users.AsNoTracking().AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        return Task.FromResult(query);
    }

    public async Task<int> CountByFilterAsync(Expression<Func<User, bool>> filter)
    {
        return await _context.Users.CountAsync(filter);
    }
}
