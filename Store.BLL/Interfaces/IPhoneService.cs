using System.Linq.Expressions;
using Store.BLL.DTO;
using Store.DAL.Entities.Phone;

namespace Store.BLL.Interfaces;

public interface IPhoneService
{
    PhoneDTO GetItem(int? id);
    
    PhoneDTO GetItemWithInclude(int? id, params Expression<Func<Phone, object>>[] includeProperties);

    IEnumerable<PhoneDTO> GetAll();
    
    IEnumerable<PhoneDTO> GetAllWithInclude(params Expression<Func<Phone, object>>[] includeProperties);

    IEnumerable<PhoneDTO> GetWithFiltersAndInclude(Expression<Func<Phone, bool>> predicate,
                    params Expression<Func<Phone, object>>[] includeProperties);
}