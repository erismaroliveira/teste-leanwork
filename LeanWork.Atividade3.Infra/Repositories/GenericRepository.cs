using LeanWork.Atividade3.Infra.Contexts;
using LeanWork.Atividade3.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeanWork.Atividade3.Infra.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly LeanWorkContext Context;

    public GenericRepository(LeanWorkContext context)
    {
        Context = context;
    }

    protected DbSet<TEntity> DbSet
    {
        get
        {
            return Context.Set<TEntity>();
        }
    }

    #region 'Comandos de CRUD'

    public TEntity Insert(TEntity model)
    {
        DbSet.Add(model);
        this.Save();
        return model;
    }

    public async Task<TEntity> InsertAsync(TEntity model)
    {
        DbSet.Add(model);
        await this.SaveAsync();
        return model;
    }

    public bool Update(TEntity model)
    {
        var entry = Context.Entry(model);

        DbSet.Attach(model);

        entry.State = EntityState.Modified;

        return (this.Save() > 0);
    }

    public async Task<bool> UpdateAsync(TEntity model)
    {
        var entry = Context.Entry(model);

        DbSet.Attach(model);

        entry.State = EntityState.Modified;

        return (await this.SaveAsync() > 0);
    }

    public bool Delete(TEntity model)
    {
        var entry = Context.Entry(model);

        Context.Remove(entry);

        return (this.Save() > 0);
    }

    public async Task<bool> DeleteAsync(TEntity model)
    {
        var entry = Context.Entry(model);

        DbSet.Attach(model);

        entry.State = EntityState.Deleted;

        return (await this.SaveAsync() > 0);
    }

    public bool Delete(Expression<Func<TEntity, bool>> where)
    {
        var model = DbSet.Where<TEntity>(where).FirstOrDefault<TEntity>();

        return (model != null) && Delete(model);
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where)
    {
        var model = DbSet.Where<TEntity>(where).FirstOrDefault<TEntity>();

        return (model != null) && await DeleteAsync(model);
    }

    public bool Delete(params object[] Keys)
    {
        var model = DbSet.Find(Keys);
        return (model != null) && Delete(model);
    }

    public async Task<bool> DeleteAsync(params object[] Keys)
    {
        var model = DbSet.Find(Keys);
        return (model != null) && await DeleteAsync(model);
    }

    public List<TEntity> InsertRange(List<TEntity> model)
    {
        try
        {
            DbSet.AddRange(model);
            this.Save();
            return model;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool UpdateRange(List<TEntity> model)
    {
        foreach (var data in model)
        {

            var entry = Context.Entry(data);
            DbSet.Attach(data);
            entry.State = EntityState.Modified;
        }

        return (this.Save() > 0);
    }


    #endregion

    #region 'Comandos de Busca'

    public TEntity Find(params object[] Keys)
    {
        return DbSet.Find(Keys);
    }

    public async Task<TEntity> FindAsync(params object[] Keys)
    {
        return await DbSet.FindAsync(Keys);
    }

    public TEntity Find(Expression<Func<TEntity, bool>> where)
    {
        return DbSet.Where<TEntity>(where).FirstOrDefault<TEntity>();
    }

    public TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        if (includeProperties != null && includeProperties.Length != 0)
        {
            var q = DbSet.Include(includeProperties.First());

            foreach (var property in includeProperties.Skip(1))
            {
                q = q.Include(property);
            }

            return q.SingleOrDefault(predicate);
        }

        return DbSet.SingleOrDefault(predicate);
    }

    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        var result = DbSet.AsQueryable();

        if (include != null)
            result = include(result);

        return DbSet.Where(predicate).AsQueryable();
    }

    public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where)
    {
        return DbSet.Where<TEntity>(where);
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where)
    {
        return await DbSet.Where<TEntity>(where).FirstOrDefaultAsync<TEntity>();
    }

    public IQueryable<TEntity> Get()
    {
        return DbSet;
    }

    public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes)
    {

        return includes.Aggregate(this.Get(),
            (current, expression) => current.Include(expression));
    }

    #endregion

    #region 'Comandos Genéricos'

    public int Save()
    {
        return this.Context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await this.Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        this.Dispose();
    }

    #endregion
}
