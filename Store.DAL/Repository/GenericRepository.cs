using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.DAL.EF;
using Store.DAL.Entities.Base;

namespace Store.DAL.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ItemBase
{
    private readonly StoreContext _db;
    private readonly DbSet<TEntity> _table;
    
    public GenericRepository()
    {
        _db = new StoreContext();
        _table = _db.Set<TEntity>();
    }
    
    public void Add(TEntity item)
    {
        _table.Add(item);
        Save();
    }

    public void Update(TEntity item)
    {
        _table.Update(item);
        Save();
    }

    public void Delete(TEntity item)
    {
        _table.Remove(item);
        Save();
    }

    public void Delete(int id)
    {
        TEntity? item = GetItem(id);
        if (item != null)
        {
            Delete(item);
        }
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    public TEntity GetItem(int? id)
    {
        return _table.Find(id);
    }

    public TEntity GetItemWithInclude(int? id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return GetAllWithInclude(includeProperties).First(i => i.Id == id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _table;
    }

    public IEnumerable<TEntity> GetAllWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return Include(includeProperties);
    }
    
    private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _table.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) 
                => current.Include(includeProperty));
    }
}