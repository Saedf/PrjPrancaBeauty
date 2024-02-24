using Microsoft.EntityFrameworkCore;

namespace FrameWork.Domain.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> DbEntities { get; }

        IQueryable<TEntity> Get { get; }
        IQueryable<TEntity> GetNoTraking { get; }

        Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true);

        Task<TEntity> GetById(CancellationToken cancellationToken, params object[] idies);

        Task<int> SaveChangeAsync();

    }
}
