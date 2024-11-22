using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Examination.System.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.Now;
        //entity.CreatedBy=userId;

        await _dbSet.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        //_dbSet.Remove(entity);
        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        //entity.DeletedBy = User.id;
        //SaveInclude(entity, nameof(entity.IsDeleted));
        SaveInclude(entity, p => p.IsDeleted, p => p.DeletedAt);
    }
    public void Undelete(TEntity entity)
    {
        entity.IsDeleted = false;
        entity.DeletedAt = null;
        //entity.DeletedBy = null;
        SaveInclude(entity, p => p.IsDeleted, p => p.DeletedAt);
    }

    public void HardDelete(TEntity entity) => _dbSet.Remove(entity);
    public IQueryable<TEntity> GetAll() => _dbSet.Where(e => !e.IsDeleted);
    public IQueryable<TEntity> GetAllWithDeleted() => _dbSet;
    public TEntity? GetById(int id) => _dbSet.FirstOrDefault(x => x.Id == id);
    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) => GetAll().Where(expression);
    public async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();

    public void SaveInclude(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
    {
        var local = _dbSet.Local.FirstOrDefault(x => x.Id == entity.Id);

        EntityEntry<TEntity> entityEntry = null;

        if (local is null)
            entityEntry = _appDbContext.Entry(entity);
        else
            entityEntry = _appDbContext.ChangeTracker.Entries<TEntity>()
                .First(x => x.Entity.Id == entity.Id);

        foreach (var propertyExpression in propertyExpressions)
        {
            var propertyToUpdate = entityEntry.Property(propertyExpression);
            var properyName = propertyToUpdate.Metadata.Name;
            propertyToUpdate.CurrentValue = entity.GetType().GetProperty(properyName)?.GetValue(entity);
            propertyToUpdate.IsModified = true;
        }

        //    foreach (var property in entityEntry.Properties)
        //    {
        //        if (properties.Contains(property.Metadata.Name))
        //        {
        //            property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name)?.GetValue(entity);
        //            property.IsModified = true;
        //        }
        //    }
    }

    public void SaveExclude(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
    {
        var propertiesToExclude = new HashSet<string>(propertyExpressions.Select(e => ((MemberExpression)e.Body).Member.Name));

        var local = _dbSet.Local.FirstOrDefault(i => i.Id == entity.Id);
        EntityEntry<TEntity> entityEntry = null;
        if (local is null)
            entityEntry = _appDbContext.Entry(entity);
        else
            entityEntry = _appDbContext.ChangeTracker.Entries<TEntity>().First(i => i.Entity.Id == entity.Id);

        foreach (var propertyEntry in entityEntry.Properties)
        {
            var propertyName = propertyEntry.Metadata.Name;

            if (propertiesToExclude.Contains(propertyName))
                propertyEntry.IsModified = false;
            else
                propertyEntry.IsModified = true;
        }
    }
}
