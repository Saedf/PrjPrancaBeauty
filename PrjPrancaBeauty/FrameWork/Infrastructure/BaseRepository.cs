using FrameWork.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.Infrastructure
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContext dbContext;
        public DbSet<TEntity> DbEntities { get; }

        public BaseRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
            DbEntities = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get => DbEntities;

        public IQueryable<TEntity> GetNoTraking => DbEntities.AsNoTracking();

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true)
        {
            await DbEntities.AddAsync(entity, cancellationToken);
            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true)
        {
            await this.DbEntities.AddRangeAsync(entities, cancellationToken);
            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.Remove(entity);
            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.RemoveRange(entities);
            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetById(CancellationToken cancellationToken, params object[] idies)
        {
            return await DbEntities.FindAsync(idies, cancellationToken);
        }

        public virtual async Task<int> SaveChangeAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.Update(entity);
            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool autoSave = true)
        {
            DbEntities.UpdateRange(entities);
            if (autoSave)
                await dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
