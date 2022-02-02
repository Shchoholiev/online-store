using System.Linq.Expressions;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.BLL.Mappers;
using Store.DAL.Entities.Phone;
using Store.DAL.Repository;

namespace Store.BLL.Services;

public class PhoneService : IPhoneService
{
    private readonly IGenericRepository<Phone> _repository;

    private readonly Mapper _mapper = new();

    public PhoneService(IGenericRepository<Phone> repository)
    {
        this._repository = repository;
    }

    public PhoneDTO GetItem(int? id)
    {
        return this._mapper.Map(this._repository.GetItem(id));
    }

    public PhoneDTO GetItem(int? id, params Expression<Func<Phone, object>>[] includeProperties)
    {
        return this._mapper.Map(this._repository.GetItem(id, includeProperties));
    }

    public IEnumerable<PhoneDTO> GetAll()
    {
        return this._mapper.Map(this._repository.GetAll());
    }

    public IEnumerable<PhoneDTO> GetAll(Expression<Func<Phone, bool>> predicate,
                    params Expression<Func<Phone, object>>[] includeProperties)
    {
        var phones = this._repository.GetAll(predicate, includeProperties);
        return this._mapper.Map(phones);
    }

    public IEnumerable<PhoneDTO> GetAll(params Expression<Func<Phone, object>>[] includeProperties)
    {
        return this._mapper.Map(this._repository.GetAll(includeProperties));
    }
}