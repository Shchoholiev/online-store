using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DTO;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;
using Store.BLL.Mappers;
using Store.DAL.Entities.Identity;
using System.Security.Claims;

namespace Store.BLL.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    
    private readonly SignInManager<User> _signInManager;

    private readonly Mapper _mapper = new();

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
    }
    
    public async Task<OperationDetails> Register(UserDTO userDto, string password)
    {
        var dbUser = await _userManager.FindByEmailAsync(userDto.Email);
        if (dbUser != null) 
            return new OperationDetails("This email already used.");

        dbUser = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == userDto.PhoneNumber);
        if (dbUser != null)
            return new OperationDetails("This email already used.");

        var user = _mapper.Map(userDto);

        var operationDetails = new OperationDetails();
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                operationDetails.AddError(error.Description);
            }
        }
        else
        {
            await _signInManager.SignInAsync(user, false);
        }

        operationDetails.Succeeded = result.Succeeded;
        return operationDetails;
    }

    public async Task<OperationDetails> Login(UserDTO userDto, string password, bool rememberMe)
    {
        var dbUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == userDto.Email.ToUpper()
                                                                        || u.PhoneNumber == userDto.PhoneNumber);

        if (dbUser == null)
            return new OperationDetails();
        
        var result = await _signInManager.PasswordSignInAsync(dbUser.UserName,
            password, rememberMe, lockoutOnFailure: false);

        return new OperationDetails() { Succeeded = result.Succeeded};
    }

    public async Task<OperationDetails> Logout()
    {
        await _signInManager.SignOutAsync();
        return new OperationDetails() { Succeeded = true };
    }

    public async Task<User> GetCurrentUser(ClaimsPrincipal claims)
    {
        var user = await _userManager.GetUserAsync(claims);
        return user;
    }
}