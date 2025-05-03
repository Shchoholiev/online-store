using System.Linq.Expressions;

namespace Store.DAL.Repository;

public interface IGenericRepository<TEntity>
{
    void Add(TEntity item);
        
    void Update (TEntity item);
        
    void Delete (TEntity item);
        
    void Delete (int id);
        
    void Save();

    void Attach(params object[] obj);

    TEntity? GetItem (int? id);
        
    TEntity? GetItem(int? id, params Expression<Func<TEntity, object>>[] includeProperties);

    IEnumerable<TEntity> GetAll();

    IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate,
                        params Expression<Func<TEntity, object>>[] includeProperties);

    IEnumerable<TEntity> GetPage(int pageSize, int pageNumber);

    int GetCount();
}