using System.Linq.Expressions;
using Store.BLL.DTO;
using Store.DAL.Entities.Phone;

namespace Store.BLL.Interfaces;

public interface IPhoneService
{
    PhoneDTO GetItem(int? id);
    
    PhoneDTO GetItem(int? id, params Expression<Func<Phone, object>>[] includeProperties);

    IEnumerable<PhoneDTO> GetAll();
    
    IEnumerable<PhoneDTO> GetAll(params Expression<Func<Phone, object>>[] includeProperties);

    IEnumerable<PhoneDTO> GetAll(Expression<Func<Phone, bool>> predicate,
                    params Expression<Func<Phone, object>>[] includeProperties);

    public IEnumerable<PhoneDTO> GetPage(int pageSize, int pageNumber);

    public int GetCount();
}