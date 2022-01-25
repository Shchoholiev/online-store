using System.Linq.Expressions;
using AutoMapper;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.DAL.Entities.Phone;
using Store.DAL.Repository;

namespace Store.BLL.Services;

public class PhoneService : IPhoneService
{
    private readonly IGenericRepository<Phone> _repository;

    private readonly Mapper.Mapper _mapper = new();

    public PhoneService(IGenericRepository<Phone> repository)
    {
        _repository = repository;
    }

    public PhoneDTO GetItem(int? id)
    {
        return _mapper.Map(_repository.GetItem(id));
    }

    public PhoneDTO GetItemWithInclude(int? id, params Expression<Func<Phone, object>>[] includeProperties)
    {
        return _mapper.Map(_repository.GetItemWithInclude(id, includeProperties));
    }

    public IEnumerable<PhoneDTO> GetAll()
    {
        return _mapper.Map(_repository.GetAll());
    }

    public IEnumerable<PhoneDTO> GetWithFiltersAndInclude(Expression<Func<Phone, bool>> predicate,
                    params Expression<Func<Phone, object>>[] includeProperties)
    {
        var phones = _repository.GetWithFiltersAndInclude(predicate, includeProperties);
        return _mapper.Map(phones);
    }

    public IEnumerable<PhoneDTO> GetAllWithInclude(params Expression<Func<Phone, object>>[] includeProperties)
    {
        return _mapper.Map(_repository.GetAllWithInclude(includeProperties));
    }
}