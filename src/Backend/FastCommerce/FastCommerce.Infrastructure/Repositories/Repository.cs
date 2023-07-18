using FastCommerce.Domain.Entities;
using FastCommerce.Domain.Interfaces;
using FastCommerce.Infrastructure.Specifications;
using FastCommerce.Infrastructure.SqlServer.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FastCommerce.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly FastCommerceDbContext _dbContext;

    public Repository(FastCommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(specification);

        return await Filter(specification)
            .AnyAsync(cancellationToken);
    }

    public async Task<TEntity?> FindSingleAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(specification);

        return await Filter(specification)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity?> FindOneAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(specification);

        return await Filter(specification)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<TEntity>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(specification);

        return await Filter(specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default)
    {
        return await Filter(spec, applyPaging: false)
            .AsNoTracking()
            .CountAsync(cancellationToken);
    }

    public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null || !entities.Any())
        {
            return entities;
        }

        foreach (var entity in entities)
        {
            var entry = _dbContext.Entry(entity);

            if (entry.State == EntityState.Detached && _dbContext.Entry(entity).IsKeySet)
            {
                _dbContext.Attach(entity);
                entry.State = EntityState.Modified;
            }

            if (!_dbContext.Entry(entity).IsKeySet)
            {
                _dbContext.Update(entity);
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entities;
    }


    public Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return InsertInternalAsync(entity, cancellationToken);
    }

    public Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return InsertRangeInternalAsync(entities, cancellationToken);
    }

    public Task<TEntity> UpdateAsync(TEntity entity, IUpdateSpecification<TEntity> specification = default, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return UpdateInternalAsync(entity, specification, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbEntity = await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);

        if (dbEntity is null)
        {
            throw new InvalidOperationException($"Entity with id {id} does not exist");
        }

        _dbContext.Remove(dbEntity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            _dbContext.Remove(entity);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<TEntity> InsertInternalAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    private async Task<IEnumerable<TEntity>> InsertRangeInternalAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbContext.AddRangeAsync(entities, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entities;
    }

    private async Task<TEntity> UpdateInternalAsync(TEntity entity, IUpdateSpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var entry = _dbContext.Entry(entity);

        if (entry.State == EntityState.Detached && _dbContext.Entry(entity).IsKeySet)
        {
            _dbContext.Attach(entity);
            entry.State = EntityState.Modified;
            foreach (var property in entity.GetType().GetProperties().Where(property => typeof(Entity).IsAssignableFrom(property.PropertyType)))
            {
                var subEntity = (Entity)property.GetValue(entity);
                if (subEntity != null && _dbContext.Entry(subEntity).IsKeySet)
                {
                    var subentry = _dbContext.Entry(subEntity);
                    _dbContext.Attach(subEntity);
                    subentry.State = EntityState.Modified;
                }
            }

            if (specification?.Includes.Any() ?? false)
            {
                await AttachIncludedCollections(_dbContext.Entry(entity), specification, cancellationToken);
            }
        }

        if (!_dbContext.Entry(entity).IsKeySet)
        {
            _dbContext.Update(entity);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    private IQueryable<TEntity> Filter(ISpecification<TEntity> spec, bool applyPaging = true)
    {
        return SpecificationEvaluator<TEntity>
            .GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec, applyPaging);
    }

    private async Task AttachIncludedCollections(EntityEntry<TEntity> entity, IUpdateSpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var includedCollections = entity.Collections.Where(c =>
            specification.Includes.Any(
                i => i.Body.ToString().Contains(c.Metadata.Name) && i.Body.Type == c.Metadata.ClrType));

        foreach (var collectionEntry in includedCollections)
        {
            await AttachCollectionItems(collectionEntry, cancellationToken);
        }
    }

    private async Task AttachCollectionItems(CollectionEntry collectionEntry, CancellationToken cancellationToken = default)
    {
        var currentCollection = (collectionEntry.CurrentValue as IEnumerable<IEntity>).ToList();
        var existingCollection = await (collectionEntry.Query() as IQueryable<IEntity>).ToListAsync(cancellationToken);

        foreach (var entity in currentCollection.Except(existingCollection))
        {
            AttachCollectionItem(entity, EntityState.Added);
        }

        foreach (var entity in existingCollection.Except(currentCollection))
        {
            AttachCollectionItem(entity, EntityState.Deleted);
        }

        foreach (var entity in existingCollection.Intersect(currentCollection))
        {
            AttachCollectionItem(entity, EntityState.Modified);
        }
    }

    private void AttachCollectionItem(IEntity entity, EntityState entityState)
    {
        var entry = _dbContext.Entry(entity);
        _dbContext.Attach(entity);
        entry.State = entityState;
    }
}
