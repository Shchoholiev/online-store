using Microsoft.EntityFrameworkCore;
using Store.DAL.EF;
using Store.DAL.Entities.Base;
using System.Linq.Expressions;

namespace Store.DAL.Repository
{
    public class ItemsRepository<TItem> : IGenericRepository<TItem> where TItem : ItemBase
    {
        private readonly StoreContext _db;
        private readonly DbSet<TItem> _table;

        public ItemsRepository()
        {
            _db = new StoreContext();
            _table = _db.Set<TItem>();
        }

        public void Add(TItem item)
        {
            _table.Add(item);
            Save();
        }

        public void Update(TItem item)
        {
            _table.Update(item);
            Save();
        }

        public void Delete(TItem item)
        {
            _table.Remove(item);
            Save();
        }

        public void Delete(int id)
        {
            TItem? item = GetItem(id);
            if (item != null)
            {
                Delete(item);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public TItem GetItem(int? id)
        {
            return GetAllWithInclude().FirstOrDefault(i => i.Id == id);
        }

        public TItem GetItemWithInclude(int? id, params Expression<Func<TItem, object>>[] includeProperties)
        {
            return GetAllWithInclude(includeProperties).FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<TItem> GetAll()
        {
            return _table.AsNoTracking();
        }

        public IEnumerable<TItem> GetWithFilters(Expression<Func<TItem, bool>> predicate)
        {
            var entities = _table.Where(predicate);
            return entities;
        }

        public IEnumerable<TItem> GetWithFiltersAndInclude(Expression<Func<TItem, bool>> predicate,
            params Expression<Func<TItem, object>>[] includeProperties)
        {
            return IncludeWithFilters(predicate, includeProperties);
        }

        public IEnumerable<TItem> GetAllWithInclude(params Expression<Func<TItem, object>>[] includeProperties)
        {
            return Include(includeProperties);
        }

        private IQueryable<TItem> Include(params Expression<Func<TItem, object>>[] includeProperties)
        {
            List<Expression<Func<TItem, object>>> include = new()
            {
                i => i.Brand,
                i => i.Model
            };
            includeProperties.Union(include);

            IQueryable<TItem> query = _table.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty)
                    => current.Include(includeProperty));
        }

        private IQueryable<TItem> IncludeWithFilters(Expression<Func<TItem, bool>> predicate,
            params Expression<Func<TItem, object>>[] includeProperties)
        {
            IQueryable<TItem> query = _table.AsNoTracking().Where(predicate);
            return includeProperties
                .Aggregate(query, (current, includeProperty)
                    => current.Include(includeProperty));
        }

        public void Attach(params object[] obj)
        {
            foreach (var o in obj)
            {
                _db.Attach(o);
            }
        }
    }
}
