using Application.Repositery;
using Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using Presistance.DataBase;
using System.Collections;
using System.Data.Entity;

namespace Application.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _context;
        private readonly UserManager<User>? _manager;
        private readonly IUserSerive? _user;
        private Hashtable? _repositories;
        private bool disposed;

        public UnitOfWork(DataContext context, IUserSerive user, UserManager<User> manager)
        {
            _context = context;
            _user = user;
            _manager = manager;
        }

        public IDataContext Context => _context!;

        public async Task<int> CommitAsync(CancellationToken cancellationToken) 
            => await _context!.SaveChangesAsync(cancellationToken);

        public async Task<int> Commit() => await Task.FromResult(_context!.SaveChanges());

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

        public async Task<User> GetUser()
        {
            try
            {
                return await _context!.Users.FirstOrDefaultAsync(e => e.Id == _user!.UserId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IRepositoryAsync<T> Repository<T>() where T : class
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

        public Task Rollback()
        {
            _context!.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }
    }
}
