using System.Linq.Expressions;

namespace Application.Repositery
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(Guid Id);
        IQueryable<TEntity> GetToQueryable();
        Task<IQueryable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> Expression);
    }

}
