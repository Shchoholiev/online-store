using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Areas.Identity.ViewModels;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.ViewMappers;

namespace Store.Areas.Identity.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly IUserService _userService;

    private readonly IShoppingCartService _shoppingCartService;

    private readonly Mapper _mapper = new();

    public AccountController(IUserService userService, IShoppingCartService shoppingCartService)
    {
        this._userService = userService;
        this._shoppingCartService = shoppingCartService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register(string returnUrl)
    {
        returnUrl = this._userService.CheckReturnUrl(returnUrl);
        return View(new RegisterViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new UserDTO { Name = model.Name, Email = model.Email, PhoneNumber = model.PhoneNumber };
            var result = await this._userService.Register(user, model.Password);

            if (result.Succeeded)
            {
                this.SetCookies(user.Name);
                //this.CookiesCartToDatabase(result.Messages.FirstOrDefault());
                return Redirect(model.ReturnUrl);
            }
            else
            {
                foreach (var error in result.Messages)
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
        returnUrl = this._userService.CheckReturnUrl(returnUrl);
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
            var result = await this._userService.Login(user, model.Password, model.RememberMe);
                    
            if (result.Succeeded)
            {
                this.SetCookies(result.Messages.FirstOrDefault());
                //this.CookiesCartToDatabase(result.Messages.LastOrDefault());
                return Redirect(model.ReturnUrl);
            }
            else
            {
                foreach (var error in result.Messages)
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
        await this._userService.Logout();
        Response.Cookies.Append("userName", string.Empty, new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
        return RedirectToAction("Index", "Home", new {area = ""});
    }

    public async Task<IActionResult> Index()
    {
        var userDTO = await this._userService.GetCurrentUser(User);
        var user = this._mapper.Map(userDTO);

        return View(user);
    }

    private void SetCookies(string userName)
    {
        Response.Cookies.Append("userName", userName);
    }

    private void CookiesCartToDatabase(string userId)
    {
        var cookies = Request.Cookies["StoreName_CartItems"];
        if (cookies != null)
        {
            this._shoppingCartService.AddItems(cookies, userId);
            Response.Cookies.Append("StoreName_CartItems", string.Empty, new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
        }
    }
}