using Microsoft.AspNetCore.Identity;
using Store.BLL.DTO;
using Store.BLL.Infrastructure;

namespace Store.BLL.Interfaces;

public interface IUserService<TUser, TUserDTO> where TUser : IdentityUser
{
    public Task<OperationDetails> Register(TUserDTO userDto, string password);

    public Task<OperationDetails> Login(TUserDTO userDto, string password, bool rememberMe);

    public Task<OperationDetails> Logout();
}