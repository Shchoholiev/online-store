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
        var operationDetails = new OperationDetails();

        var dbUser = await _userManager.FindByEmailAsync(userDto.Email);
        if (dbUser != null)
            operationDetails.AddMessage("This email already used.");

        dbUser = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == userDto.PhoneNumber);
        if (dbUser != null)
            operationDetails.AddMessage("This phone already used.");

        if (operationDetails.Messages.Count > 0)
        {
            return operationDetails;
        }

        var user = _mapper.Map(userDto);
        user.Id = DateTime.Now.Ticks.ToString();

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
        }
        else
        {
            foreach (var error in result.Errors)
            {
                operationDetails.AddMessage(error.Description);
            }
        }

        operationDetails.Succeeded = result.Succeeded;
        operationDetails.AddMessage(user.Id);
        return operationDetails;
    }

    public async Task<OperationDetails> Login(UserDTO userDto, string password, bool rememberMe)
    {
        var dbUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == userDto.Email.ToUpper()
                                                                        || u.PhoneNumber == userDto.PhoneNumber);

        if (dbUser == null)
        {
            return new OperationDetails("Incorrect email or phone number");
        }
        
        var result = await _signInManager.PasswordSignInAsync(dbUser.UserName,
            password, rememberMe, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            return new OperationDetails("Incorrect password");
        }

        var operationDetails = new OperationDetails($"{dbUser.Name}") { Succeeded = true };
        operationDetails.AddMessage(dbUser.Id);
        return operationDetails;
    }

    public async Task<OperationDetails> Logout()
    {
        await _signInManager.SignOutAsync();
        return new OperationDetails() { Succeeded = true };
    }

    public async Task<UserDTO> GetCurrentUser(ClaimsPrincipal claims)
    {
        var user = await this._userManager.GetUserAsync(claims);
        var userDTO = this._mapper.Map(user);

        return userDTO;
    }

    public string CheckReturnUrl(string returnUrl)
    {
        if (string.IsNullOrEmpty(returnUrl)
           || returnUrl.Contains("Register")
           || returnUrl.Contains("Login"))
        {
            return "/";
        }
        return returnUrl;
    }
}