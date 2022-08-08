using Domain.Authentication;
using Presistance.DataBase;

namespace Application.Repositery
{
    public interface IUnitOfWork : IDisposable 
    {
        IDataContext Context { get; }
        IRepositoryAsync<T> Repository<T>() where T : class;
        Task<int> CommitAsync(CancellationToken cancellationToken);
        Task Rollback();
        Task<User> GetUser();
    }
}
