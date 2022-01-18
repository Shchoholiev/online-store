using System.Linq.Expressions;

namespace Store.DAL.Repository;

public interface IGenericRepository<TEntity>
{
    void Add(TEntity item);
        
    void Update (TEntity item);
        
    void Delete (TEntity item);
        
    void Delete (int id);
        
    void Save();
        
    TEntity GetItem (int? id);
        
    TEntity GetItemWithInclude(int? id, params Expression<Func<TEntity, object>>[] includeProperties);
    
    IEnumerable<TEntity> GetAll();
    
    IEnumerable<TEntity> GetAllWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
}