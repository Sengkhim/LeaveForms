using Application.Repositery;
using Domain.Authentication;
using Domain.Entites.BaseEntity;
using Microsoft.AspNetCore.Identity;
using Presistance.DataBase;
using System.Collections;
using System.Data;

namespace Application.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _context;
        private readonly UserManager<User>? _manager;
        private readonly ICurrentUserService? _user;
        private Hashtable? _repositories;
        private bool disposed;

        public UnitOfWork(DataContext context, ICurrentUserService user, UserManager<User> manager)
        {
            _context = context;
            _user = user;
            _manager = manager;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context!.SaveChangesAsync(cancellationToken);
        }

        public  IDbConnection DbConnector()
        {
            return _context!.Connection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    //dispose managed resources
                    _context!.Dispose();
            //dispose unmanaged resources
            disposed = true;
        }

        public IRepositoryAsync<T> Repository<T>() where T : Entity<Guid>
        {
            _repositories ??= new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryAsync<T>);

                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepositoryAsync<T>)_repositories[type]!;
        }
    }
}
