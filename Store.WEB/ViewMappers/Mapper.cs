using AutoMapper;
using Store.BLL.DTO;
using Store.ViewModels;

namespace Store.ViewMappers
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ItemBaseDTO, ItemBaseViewModel>();
            cfg.CreateMap<CartItemDTO, CartItemViewModel>();

            cfg.CreateMap<PhoneDTO, PhoneViewModel>();
            cfg.CreateMap<PhoneSpecificationsDTO, PhoneViewModel>()
                .ForMember(s => s.Id, opt => opt.Ignore());

        }).CreateMapper();

        public PhoneViewModel Map(PhoneDTO source)
        {
            var mapped = _mapper.Map<PhoneViewModel>(source);
            _mapper.Map(source.Specifications, mapped);

            return mapped;
        }

        public IEnumerable<CartItemViewModel> Map(IEnumerable<CartItemDTO> source)
        {
            return _mapper.Map<IEnumerable<CartItemViewModel>>(source);
        }

        public IEnumerable<PhoneViewModel> Map(IEnumerable<PhoneDTO> source)
        {
            return _mapper.Map<IEnumerable<PhoneViewModel>>(source);
        }        
    }
}
