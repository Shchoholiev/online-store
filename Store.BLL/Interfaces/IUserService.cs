using Store.BLL.DTO;
using Store.BLL.Infrastructure;
using Store.DAL.Entities.Identity;
using System.Security.Claims;

namespace Store.BLL.Interfaces;

public interface IUserService
{
    Task<OperationDetails> Register(UserDTO userDto, string password);

    Task<OperationDetails> Login(UserDTO userDto, string password, bool rememberMe);

    Task<OperationDetails> Logout();

    Task<UserDTO> GetCurrentUser(ClaimsPrincipal claims);

    string CheckReturnUrl(string returnUrl);
}