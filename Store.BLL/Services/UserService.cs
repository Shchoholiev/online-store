using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DTO;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;

namespace Store.BLL.Services;

public class UserService<TUser, TUserDTO> : IUserService<TUser, TUserDTO> where TUser : IdentityUser where TUserDTO : UserDTO
{
    private readonly UserManager<TUser> _userManager;
    
    private readonly SignInManager<TUser> _signInManager;

    private readonly IMapper _mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<TUserDTO, TUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));
    }).CreateMapper();

    public UserService(UserManager<TUser> userManager, SignInManager<TUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<OperationDetails> Register(TUserDTO userDto, string password)
    {
        var operationDetails = new OperationDetails();
        
        var dbUser = await _userManager.FindByEmailAsync(userDto.Email);
        if (dbUser != null) 
            operationDetails.AddError("This email already used.");

        dbUser = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == userDto.PhoneNumber);
        if (dbUser != null) 
            operationDetails.AddError("This phone number already used.");

        if (operationDetails.ErrorsCount() > 0)
            return operationDetails;

        var user = _mapper.Map<TUser>(userDto);
        
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded )
        {
            foreach (var error in result.Errors)
            {
                operationDetails.AddError(error.Description);
            }
        }

        await _signInManager.SignInAsync(user, false);

        operationDetails.Succeeded = true;
        return operationDetails;
    }

    public async Task<OperationDetails> Login(TUserDTO userDto, string password, bool rememberMe)
    {
        var dbUser = await _userManager.Users.FirstAsync(u => u.NormalizedEmail == userDto.Email.ToUpper()
                                                                        || u.PhoneNumber == userDto.PhoneNumber);
        
        var result = await _signInManager.PasswordSignInAsync(dbUser.UserName,
            password, rememberMe, lockoutOnFailure: false);

        return new OperationDetails() {Succeeded = result.Succeeded};
    }

    public async Task<OperationDetails> Logout()
    {
        await _signInManager.SignOutAsync();
        return new OperationDetails() {Succeeded = true};
    }
}