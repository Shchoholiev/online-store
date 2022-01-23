﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DTO;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;
using Store.DAL.Entities.Identity;

namespace Store.BLL.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    
    private readonly SignInManager<User> _signInManager;

    private readonly IMapper _mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<UserDTO, User>().ForMember(dest => dest.UserName, 
            opt => opt.MapFrom(src => src.Name));
    }).CreateMapper();

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<OperationDetails> Register(UserDTO userDto, string password)
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

        var user = _mapper.Map<User>(userDto);
        
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

    public async Task<OperationDetails> Login(UserDTO userDto, string password, bool rememberMe)
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
        return new OperationDetails() { Succeeded = true };
    }
}