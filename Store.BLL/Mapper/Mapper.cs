using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.BLL.DTO;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;
using Store.DAL.Entities.Orders;
using Store.DAL.Entities.Phone;

namespace Store.BLL.Mapper
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDTO, User>().ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Name));

            cfg.CreateMap<PhoneSpecifications, PhoneSpecificationsDTO>();
            cfg.CreateMap<Phone, PhoneDTO>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.Name));

            cfg.CreateMap<OrderDTO, Order>();

            cfg.CreateMap<ItemBaseDTO, ItemBase>();

            cfg.CreateMap<ItemBase, ItemBaseDTO>();

            cfg.CreateMap<CartItemDTO, CartItem>();
            cfg.CreateMap<Order, OrderDTO>();

            cfg.CreateMap<CartItem, CartItemDTO>();

        }).CreateMapper();

        public User Map(UserDTO source)
        {
            return _mapper.Map<User>(source);
        }

        public Order Map(OrderDTO source)
        {
            return _mapper.Map<Order>(source);
        }

        public CartItem Map(CartItemDTO source)
        {
            return _mapper.Map<CartItem>(source);
        }

        public PhoneDTO Map(Phone source)
        {
            return _mapper.Map<PhoneDTO>(source);
        }

        public IEnumerable<PhoneDTO> Map(IEnumerable<Phone> source)
        {
            return _mapper.Map<IEnumerable<PhoneDTO>>(source);
        }

        public IEnumerable<OrderDTO> Map(IEnumerable<Order> source)
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(source);
        }

        public IEnumerable<CartItemDTO> Map(IEnumerable<CartItem> source)
        {
            return _mapper.Map<IEnumerable<CartItemDTO>>(source);
        }
    }
}
