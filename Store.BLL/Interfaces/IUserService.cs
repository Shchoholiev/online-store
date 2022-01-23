using Store.BLL.DTO;
using Store.BLL.Infrastructure;

namespace Store.BLL.Interfaces;

public interface IUserService
{
    public Task<OperationDetails> Register(UserDTO userDto, string password);

    public Task<OperationDetails> Login(UserDTO userDto, string password, bool rememberMe);

    public Task<OperationDetails> Logout();
}