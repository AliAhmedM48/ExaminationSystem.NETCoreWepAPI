using Examination.System.Core.Models;
using System.Linq.Expressions;

namespace Examination.System.Core.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : BaseModel
{
    Task AddAsync(TEntity entity);
    //void Update(TEntity entity);
    //void SaveInclude(TEntity entity, params string[] properties);
    void SaveInclude(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions);
    void SaveExclude(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllWithDeleted();
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
    TEntity? GetById(int id);
    void Delete(TEntity entity);
    void Undelete(TEntity entity);
    void HardDelete(TEntity entity);
    Task SaveChangesAsync();
}
