using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Areas.Identity.ViewModels;
using Store.BLL.DTO;
using Store.BLL.Interfaces;

namespace Store.Areas.Identity.Controllers;

[Authorize] 
public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register(string returnUrl)
    {
        returnUrl = _userService.CheckReturnUrl(returnUrl);
        return View(new RegisterViewModel {ReturnUrl = returnUrl});
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new UserDTO { Name = model.Name, Email = model.Email, PhoneNumber = model.PhoneNumber};

            var result = await _userService.Register(user, model.Password);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        returnUrl = _userService.CheckReturnUrl(returnUrl);
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new UserDTO { Email = model.Login, PhoneNumber = model.Login};
            var result = await _userService.Login(user, model.Password, model.RememberMe);
                    
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
        return View(model);
    }
        
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return RedirectToAction("Index", "Home", new {area = ""});
    }
}