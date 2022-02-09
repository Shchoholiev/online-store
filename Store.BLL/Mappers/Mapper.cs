using AutoMapper;
using Store.BLL.DTO;
using Store.BLL.DTO.OrdersDTO;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;
using Store.DAL.Entities.Orders;
using Store.DAL.Entities.Phone;

namespace Store.BLL.Mappers
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDTO, User>()
            .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email ?? src.PhoneNumber));

            cfg.CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));

            cfg.CreateMap<PhoneSpecifications, PhoneSpecificationsDTO>();
            cfg.CreateMap<Phone, PhoneDTO>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.ColorHex,
                opt => opt.MapFrom(src => src.Color.Hex))
            .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src => src.Image.Link));

            cfg.CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Delivery,
                opt => opt.MapFrom(src => new DeliveryOption { Id = src.Delivery }))
                .ForMember(dest => dest.Payment,
                opt => opt.MapFrom(src => new PaymentOption { Id = src.Payment }));

            cfg.CreateMap<ItemBaseDTO, ItemBase>()
            .ForMember(dest => dest.Brand, opt => opt.Ignore())
            .ForMember(dest => dest.Model, opt => opt.Ignore())
            .ForMember(dest => dest.Color, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.Ignore());

            cfg.CreateMap<ItemBase, ItemBaseDTO>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Color,
                opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.ColorHex,
                opt => opt.MapFrom(src => src.Color.Hex))
            .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src => src.Image.Link));

            cfg.CreateMap<CartItemDTO, CartItem>();

            cfg.CreateMap<Order, OrderDTO>();

            cfg.CreateMap<CartItem, CartItemDTO>();

        }).CreateMapper();

        public User Map(UserDTO source)
        {
            return this._mapper.Map<User>(source);
        }

        public UserDTO Map(User source)
        {
            return this._mapper.Map<UserDTO>(source);
        }

        public Order Map(OrderDTO source)
        {
            return this._mapper.Map<Order>(source);
        }

        public OrderDTO Map(Order source)
        {
            return this._mapper.Map<OrderDTO>(source);
        }

        public CartItem Map(CartItemDTO source)
        {
            return this._mapper.Map<CartItem>(source);
        }

        public CartItemDTO Map(CartItem source)
        {
            return this._mapper.Map<CartItemDTO>(source);
        }

        public ItemBaseDTO Map(ItemBase source)
        {
            return this._mapper.Map<ItemBaseDTO>(source);
        }

        public PhoneDTO Map(Phone source)
        {
            return this._mapper.Map<PhoneDTO>(source);
        }

        public IEnumerable<PhoneDTO> Map(IEnumerable<Phone> source)
        {
            return this._mapper.Map<IEnumerable<PhoneDTO>>(source);
        }

        public IEnumerable<OrderDTO> Map(IEnumerable<Order> source)
        {
            return this._mapper.Map<IEnumerable<OrderDTO>>(source);
        }

        public IEnumerable<CartItemDTO> Map(IEnumerable<CartItem> source)
        {
            return this._mapper.Map<IEnumerable<CartItemDTO>>(source);
        }
    }
}
