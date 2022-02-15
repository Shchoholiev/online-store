using AutoMapper;
using Store.Areas.Identity.ViewModels;
using Store.BLL.DTO;
using Store.BLL.DTO.ItemsProperties;
using Store.BLL.DTO.OrdersDTO;
using Store.ViewModels;
using Store.ViewModels.ItemsProperties;
using Store.ViewModels.Phone;

namespace Store.ViewMappers
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ItemBaseDTO, ItemBaseViewModel>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.ColorHex,
                opt => opt.MapFrom(src => src.Color.Hex));

            cfg.CreateMap<CartItemDTO, CartItemViewModel>();

            cfg.CreateMap<PhoneDTO, PhoneViewModel>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.ColorHex,
                opt => opt.MapFrom(src => src.Color.Hex));

            cfg.CreateMap<PhoneSpecificationsDTO, PhoneViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            cfg.CreateMap<OrderDTO, OrderViewModel>()
                .ConstructUsing(o => new OrderViewModel());

            cfg.CreateMap<OrderViewModel, OrderDTO>();

            cfg.CreateMap<UserDTO, UserViewModel>();

            cfg.CreateMap<BrandDTO, BrandViewModel>();
            cfg.CreateMap<ModelDTO, ModelViewModel>();
            cfg.CreateMap<ColorDTO, ColorViewModel>();
            cfg.CreateMap<ImageDTO, ImageViewModel>();

            cfg.CreateMap<PhoneDTO, PhoneEditViewModel>()
            .ForMember(dest => dest.SpecsId,
                opt => opt.MapFrom(src => src.Specifications.Id))
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.ColorHex,
                opt => opt.MapFrom(src => src.Color.Hex));

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

        public OrderViewModel Map(OrderDTO source)
        {
            return _mapper.Map<OrderViewModel>(source);
        }

        public UserViewModel Map(UserDTO source)
        {
            return _mapper.Map<UserViewModel>(source);
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

        public IEnumerable<BrandViewModel> Map(IEnumerable<BrandDTO> source)
        {
            return _mapper.Map<IEnumerable<BrandViewModel>>(source);
        }

        public IEnumerable<ModelViewModel> Map(IEnumerable<ModelDTO> source)
        {
            return _mapper.Map<IEnumerable<ModelViewModel>>(source);
        }

        public IEnumerable<ColorViewModel> Map(IEnumerable<ColorDTO> source)
        {
            return _mapper.Map<IEnumerable<ColorViewModel>>(source);
        }

        public PhoneEditViewModel MapForEdit(PhoneDTO source)
        {
            return _mapper.Map<PhoneEditViewModel>(source);
        }
    }
}
