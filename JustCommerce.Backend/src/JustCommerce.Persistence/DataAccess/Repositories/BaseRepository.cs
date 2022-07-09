using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity>
            where TEntity : Entity, new()
    {
        protected DbSet<TEntity> _entity;
        public BaseRepository(DbSet<TEntity> entity)
        {
            _entity = entity;
        }
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entity.AddAsync(entity, cancellationToken);
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _entity.AnyAsync(c => c.Id == id, cancellationToken);
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _entity.ToListAsync(cancellationToken);
        }

        public ValueTask<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _entity.FindAsync(new object[] { id }, cancellationToken);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _entity.AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveById(Guid id)
        {
            var attachedEntity = _entity.Attach(new TEntity { Id = id });
            attachedEntity.State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
    }
}
