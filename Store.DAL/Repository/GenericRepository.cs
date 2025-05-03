using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.DAL.EF;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;

namespace Store.DAL.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
{
    private readonly StoreContext _db;
    private readonly DbSet<TEntity> _table;

    public GenericRepository()
    {
        this._db = new StoreContext();
        this._table = _db.Set<TEntity>();
    }

    public void Add(TEntity item)
    {
        this._table.Add(item);
        this.Save();
    }

    public void Update(TEntity item)
    {
        this._table.Update(item);
        this.Save();
    }

    public void Delete(TEntity item)
    {
        this._table.Remove(item);
        this.Save();
    }

    public void Delete(int id)
    {
        TEntity? item = this.GetItem(id);
        if (item != null)
        {
            this.Delete(item);
        }
    }

    public void Save()
    {
        this._db.SaveChanges();
    }

    public void Attach(params object[] obj)
    {
        foreach (var o in obj)
        {
            this._db.Attach(o);
        }
    }

    public TEntity? GetItem(int? id)
    {
        return this.GetAll(i => i.Id == id).FirstOrDefault();
    }

    public TEntity? GetItem(int? id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return this.GetAll(i => i.Id == id, includeProperties).FirstOrDefault();
    }

    public IEnumerable<TEntity> GetAll()
    {
        IQueryable<TEntity> query = this._table.AsNoTracking();
        return this.Include(query);
    }

    public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = this._table.AsNoTracking();
        return this.Include(query, includeProperties);
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = this._table.AsNoTracking().Where(predicate);
        return this.Include(query, includeProperties);
    }

    public IEnumerable<TEntity> GetPage(int pageSize, int pageNumber)
    {
        IQueryable<TEntity> query = this._table.AsNoTracking()
                                             .Skip((pageNumber - 1) * pageSize)
                                             .Take(pageSize);
        return this.Include(query);
    }

    public int GetCount()
    {
        return this._table.Count();
    }

    private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return includeProperties
            .Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));
    }
}