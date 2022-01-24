using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.BLL.DTO;
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
                 opt => opt.MapFrom(src => src.BrandId.ToString()));

            cfg.CreateMap<OrderDTO, Order>();

        }).CreateMapper();

        public User Map(UserDTO source)
        {
            return _mapper.Map<User>(source);
        }

        public PhoneDTO Map(Phone source)
        {
            return _mapper.Map<PhoneDTO>(source);
        }

        public IEnumerable<PhoneDTO> Map(IEnumerable<Phone> source)
        {
            return _mapper.Map<IEnumerable<PhoneDTO>>(source);
        }
    }
}
