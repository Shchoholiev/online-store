using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.BLL.DTO;
using Store.DAL.Entities.Identity;

namespace Store.BLL.Mapper
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDTO, User>().ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Name));
        }).CreateMapper();

        public User Map(UserDTO source)
        {
            return _mapper.Map<User>(source);
        }

    }
}
