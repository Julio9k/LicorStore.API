using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Entities;

namespace LiquorStore.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task<int> AddAsync(UserDto dto);
    Task<bool> UpdateAsync(UserDto dto);
    Task<bool> ExistsAsync(Expression<Func<User, bool>> filter);
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto?> GetByFilterAsync(Expression<Func<User, bool>>? filter = null);
    Task<IQueryable<User>> GetQueryableAsync(Expression<Func<User, bool>>? filter = null);
    Task<int> CountByFilterAsync(Expression<Func<User, bool>> filter);
}
