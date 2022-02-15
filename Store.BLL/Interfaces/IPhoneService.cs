using System.Linq.Expressions;
using Store.BLL.DTO;
using Store.BLL.DTO.ItemsProperties;
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

    IEnumerable<PhoneDTO> GetPage(int pageSize, int pageNumber);

    IEnumerable<PhoneDTO> GetPageWithAdditionalItem(int pageSize, int pageNumber);

    int GetCount();

    void Edit(int id, int amount, int price);

    void Edit(PhoneDTO phoneDTO);

    void Delete(int id);

    IEnumerable<BrandDTO> GetBrands();

    IEnumerable<ModelDTO> GetModels();

    IEnumerable<ColorDTO> GetColors();

}