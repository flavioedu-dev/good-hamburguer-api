using GoodHamburger.Domain.Entities.Base;
using System.Linq.Expressions;

namespace GoodHamburger.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<int> SaveAsync();
}
