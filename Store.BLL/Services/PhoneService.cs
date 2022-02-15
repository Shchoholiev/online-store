using System.Linq.Expressions;
using LinqKit;
using Store.BLL.DTO;
using Store.BLL.DTO.ItemsProperties;
using Store.BLL.Interfaces;
using Store.BLL.Mappers;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.ItemProperties;
using Store.DAL.Entities.Phone;
using Store.DAL.Repository;

namespace Store.BLL.Services;

public class PhoneService : IPhoneService
{
    private readonly IGenericRepository<Phone> _repository;

    private readonly IGenericRepository<Brand> _brandsRepository;

    private readonly IGenericRepository<Model> _modelsRepository;

    private readonly IGenericRepository<Color> _colorsRepository;

    private readonly Mapper _mapper = new();

    public PhoneService(IGenericRepository<Phone> repository, IGenericRepository<Brand> brandsRepository,
                        IGenericRepository<Model> modelsRepository, IGenericRepository<Color> colorsRepositor)
    {
        this._repository = repository;
        this._brandsRepository = brandsRepository;
        this._modelsRepository = modelsRepository;
        this._colorsRepository = colorsRepositor;
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

    public IEnumerable<PhoneDTO> GetPage(int pageSize, int pageNumber)
    {
        return this._mapper.Map(this._repository.GetPage(pageSize, pageNumber));
    }

    public IEnumerable<PhoneDTO> GetPageWithAdditionalItem(int pageSize, int pageNumber)
    {
        var page = this._repository.GetPage(pageSize, pageNumber).ToList();

        var phoneModels = new List<string>();
        foreach (var phone in page)
        {
            if (!phoneModels.Contains(phone.Model.Name))
            {
                phoneModels.Add(phone.Model.Name);
            }
        }

        var predicate = PredicateBuilder.New<Phone>();
        foreach (var model in phoneModels)
        {
            predicate = predicate.Or(p => p.Model.Name == model);
        }

        var otherPhones = this._repository.GetAll(predicate);
        page.AddRange(otherPhones);
        page = page.DistinctBy(p => p.Id).ToList();

        return this._mapper.Map(page);
    }

    public int GetCount()
    {
        return this._repository.GetCount();
    }

    public void Edit(int id, int amount, int price)
    {
        var phone = this._repository.GetItem(id);
        phone.Amount = amount;
        phone.Price = price;

        this._repository.Update(phone);
    }

    public void Edit(PhoneDTO phoneDTO)
    {
        var phone = this._mapper.Map(phoneDTO);
        this._repository.Attach(phone.Brand, phone.Model, phone.Color, phone.Specifications);
        foreach (var image in phone.Images)
        {
            //if (image.Id == 0)
            //{
            //    var newImage = new Image { Link = image.Link, Items = new List<ItemBase> { phone } };
            //}
            //else
            //{
                image.Items = new List<ItemBase> { phone };
                this._repository.Attach(image);
            //}
        }
        this._repository.Update(phone);
    }

    public void Delete(int id)
    {
        this._repository.Delete(id);
    }

    public IEnumerable<BrandDTO> GetBrands()
    {
        return this._mapper.Map(this._brandsRepository.GetAll());
    }

    public IEnumerable<ModelDTO> GetModels()
    {
        return this._mapper.Map(this._modelsRepository.GetAll());
    }

    public IEnumerable<ColorDTO> GetColors()
    {
        return this._mapper.Map(this._colorsRepository.GetAll());
    }
}