
using Domain.Entites.BaseEntity;
using System.Data;

namespace Application.Repositery
{
    public interface IUnitOfWork : IDisposable 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepositoryAsync<T> Repository<T>() where T : Entity<Guid>;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CommitAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDbConnection DbConnector();
    }
}
