using System.Linq.Expressions;
using Store.BLL.DTO;
using Store.DAL.Entities.Phone;

namespace Store.BLL.Interfaces;

public interface IPhoneService
{
    public PhoneDTO GetItem(int? id);
    
    public PhoneDTO GetItemWithInclude(int? id, params Expression<Func<Phone, object>>[] includeProperties);

    public IEnumerable<PhoneDTO> GetAll();
    
    public IEnumerable<PhoneDTO> GetAllWithInclude(params Expression<Func<Phone, object>>[] includeProperties);
}