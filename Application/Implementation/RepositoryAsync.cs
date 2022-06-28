using Application.Repositery;
using Microsoft.EntityFrameworkCore;
using Presistance.DataBase;
using System.Linq.Expressions;

namespace Application.Implementation
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly IDataContext _context;

        public RepositoryAsync(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Entities => _context.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IQueryable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> Expression)
        {
            var result = _context.Set<TEntity>().AsQueryable().Where(Expression);
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _context.Set<TEntity>().Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize).AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetToQueryable()
        {
           var query = _context.Set<TEntity>().AsQueryable();
           return query;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
