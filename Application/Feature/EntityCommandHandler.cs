using Application.Repositery;

namespace Application.Feature
{
    public abstract class EntityCommandHandler<T> where T : class 
    {
        /// <summary>
        /// verify entity data before commit to db
        /// </summary>
        /// <param name="unitOf"></param>
        /// <param name="UserId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<T> VerifyData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken);

        /// <summary>
        /// Create a data model
        /// </summary>
        /// <param name="unitOf"></param>
        /// <param name="UserId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<T?> EntityData(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken);

        /// <summary>
        /// add to data base
        /// </summary>
        /// <param name="unitOf"></param>
        /// <param name="UserId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<T> SavedToDbHandle(IUnitOfWork unitOf, Guid UserId, CancellationToken cancellationToken);
    }
}
