using System.Linq.Expressions;
using AutoMapper;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.DAL.Entities.Base;
using Store.DAL.Repository;

namespace Store.BLL.Services;

public class ItemsService<T, TDto, TSpecs, TSpecsDto> : IItemsService<T, TDto, TSpecs, TSpecsDto> 
    where T : ItemBase where TDto : ItemBaseDTO where TSpecs : class where TSpecsDto : class
{
    private readonly IGenericRepository<T> _repository;
    
    private readonly IMapper _mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<TSpecs, TSpecsDto>();
        cfg.CreateMap<T, TDto>();
    }).CreateMapper();
    
    public ItemsService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public TDto GetItem(int? id)
    {
        return _mapper.Map<T, TDto>(_repository.GetItem(id));
    }

    public TDto GetItemWithInclude(int? id, params Expression<Func<T, object>>[] includeProperties)
    {
        return _mapper.Map<T, TDto>(_repository.GetItemWithInclude(id, includeProperties));
    }

    public IEnumerable<TDto> GetAll()
    {
        return _mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(_repository.GetAll());
    }

    public IEnumerable<TDto> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties)
    {
        return _mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(_repository.GetAllWithInclude(includeProperties));
    }
}