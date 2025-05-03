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
            this._db = new StoreContext();
            this._table = _db.Set<TItem>();
        }

        public void Add(TItem item)
        {
            this._table.Add(item);
            this.Save();
        }

        public void Update(TItem item)
        {
            this._table.Update(item);
            this.Save();
        }

        public void Delete(TItem item)
        {
            this._table.Remove(item);
            this.Save();
        }

        public void Delete(int id)
        {
            TItem? item = this.GetItem(id);
            if (item != null)
            {
                this.Delete(item);
            }
        }

        public void Attach(params object[] objects)
        {
            foreach (var obj in objects)
            {
                this._db.Attach(obj);
            }
        }

        public void Save()
        {
            this._db.SaveChanges();
        }

        public TItem? GetItem(int? id)
        {
            return this.GetAll(i => i.Id == id).FirstOrDefault();
        }

        public TItem? GetItem(int? id, params Expression<Func<TItem, object>>[] includeProperties)
        {
            return this.GetAll(i => i.Id == id, includeProperties).FirstOrDefault();
        }

        public IEnumerable<TItem> GetAll()
        {
            IQueryable<TItem> query = this._table.AsNoTracking();
            return this.Include(query);
        }

        public IEnumerable<TItem> GetAll(params Expression<Func<TItem, object>>[] includeProperties)
        {
            IQueryable<TItem> query = this._table.AsNoTracking();
            return this.Include(query, includeProperties);
        }

        public IEnumerable<TItem> GetAll(Expression<Func<TItem, bool>> predicate,
            params Expression<Func<TItem, object>>[] includeProperties)
        {
            IQueryable<TItem> query = this._table.AsNoTracking().Where(predicate);
            return this.Include(query, includeProperties);
        }

        public IEnumerable<TItem> GetPage(int pageSize, int pageNumber)
        {
            IQueryable<TItem> query = this._table.AsNoTracking()
                                                 .Skip((pageNumber - 1) * pageSize)
                                                 .Take(pageSize);
            return this.Include(query);
        }

        public int GetCount()
        {
            return this._table.Count();
        }

        private IQueryable<TItem> Include(IQueryable<TItem> query, params Expression<Func<TItem, object>>[] includeProperties)
        {
            var include = new Expression<Func<TItem, object>>[] 
            {
                i => i.Brand,
                i => i.Model,
                i => i.Color,
                i => i.Image,
            };
            includeProperties = includeProperties.Concat(include).ToArray();

            return includeProperties
                .Aggregate(query, (current, includeProperty)
                    => current.Include(includeProperty));
        }
    }
}
