using System.Linq.Expressions;
using Store.BLL.DTO;
using Store.DAL.Entities.Base;

namespace Store.BLL.Interfaces;

public interface IItemsService<T, TDto, TSpecs, TScpecsDto> 
    where T : ItemBase where TDto : ItemBaseDTO  where TSpecs : class where TScpecsDto : class
{
    public TDto GetItem(int? id);
    
    public TDto GetItemWithInclude(int? id, params Expression<Func<T, object>>[] includeProperties);

    public IEnumerable<TDto> GetAll();
    
    public IEnumerable<TDto> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
}