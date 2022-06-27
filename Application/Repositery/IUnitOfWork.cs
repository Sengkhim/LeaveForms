
using Application.BusinessObejct;
using Domain.Authentication;
using Domain.Entites;
using System.Data;

namespace Application.Repositery
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepositoryAsync<T> Repository<T>() where T : class;
        Task<int> CommitAsync(CancellationToken cancellationToken);
        IDbConnection DbConnector();
        Task Rollback();

        /// <summary>
        ///     Get session user
        /// </summary>
        /// <returns>Subscription</returns>
        Task<User> GetUser();
        Task<Period> GetOrCreatePeriodAsync(DateTimeOffset? beginDate, DateTimeOffset? endDate);

        /// <summary>
        ///     Business object codes
        /// </summary>
        public Codes Code { get; }
    }
}
