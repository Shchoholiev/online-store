using AutoMapper;
using Store.BLL.DTO;
using Store.BLL.DTO.OrdersDTO;
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
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            cfg.CreateMap<OrderDTO, OrderViewModel>();

            cfg.CreateMap<OrderViewModel, OrderDTO>();

        }).CreateMapper();

        public PhoneViewModel Map(PhoneDTO source)
        {
            var mapped = _mapper.Map<PhoneViewModel>(source);
            _mapper.Map(source.Specifications, mapped);

            return mapped;
        }

        public OrderDTO Map(OrderViewModel source)
        {
            return _mapper.Map<OrderDTO>(source);
        }

        public IEnumerable<CartItemViewModel> Map(IEnumerable<CartItemDTO> source)
        {
            return _mapper.Map<IEnumerable<CartItemViewModel>>(source);
        }

        public IEnumerable<PhoneViewModel> Map(IEnumerable<PhoneDTO> source)
        {
            return _mapper.Map<IEnumerable<PhoneViewModel>>(source);
        }

        public IEnumerable<OrderViewModel> Map(IEnumerable<OrderDTO> source)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(source);
        }
    }
}
