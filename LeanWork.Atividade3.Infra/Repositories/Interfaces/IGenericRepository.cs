using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LeanWork.Atividade3.Infra.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity Insert(TEntity model);
    Task<TEntity> InsertAsync(TEntity model);
    List<TEntity> InsertRange(List<TEntity> model);
    bool Update(TEntity model);
    Task<bool> UpdateAsync(TEntity model);
    bool UpdateRange(List<TEntity> model);
    bool Delete(TEntity model);
    Task<bool> DeleteAsync(TEntity model);
    bool Delete(Expression<Func<TEntity, bool>> where);
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where);
    bool Delete(params object[] Keys);
    Task<bool> DeleteAsync(params object[] Keys);
    TEntity Find(params object[] Keys);
    IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where);
    Task<TEntity> FindAsync(params object[] Keys);
    TEntity Find(Expression<Func<TEntity, bool>> where);
    TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where);
    IQueryable<TEntity> Get();
    IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes);
    Int32 Save();
    Task<Int32> SaveAsync();
    void Dispose();
}
