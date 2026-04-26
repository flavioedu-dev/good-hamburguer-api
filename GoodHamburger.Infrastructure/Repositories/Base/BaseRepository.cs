using GoodHamburger.Domain.Entities.Base;
using GoodHamburger.Domain.Exceptions;
using GoodHamburger.Domain.Interfaces.Repositories.Base;
using GoodHamburger.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoodHamburger.Infrastructure.Repositories.Base;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly SqlDbContext _context;

    public BaseRepository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);

        return entity;
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;

        _context.Entry(entity).State = EntityState.Modified;

        return Task.FromResult(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var existsEntity = await GetByIdAsync(id) ?? throw new CustomResponseException($"Entidade com id {id} não encontrada.", 404);

        _context.Set<TEntity>().Remove(existsEntity);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
