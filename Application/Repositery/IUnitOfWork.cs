
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

        Task<User> GetUser();
        Task<Period> GetOrCreatePeriodAsync(DateTimeOffset? beginDate, DateTimeOffset? endDate);

    }
}
