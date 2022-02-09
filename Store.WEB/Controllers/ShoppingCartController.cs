using Microsoft.AspNetCore.Mvc;
using Store.BLL.DTO;
using Store.BLL.DTO.OrdersDTO;
using Store.BLL.Interfaces;
using Store.ViewMappers;
using Store.ViewModels;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        private readonly IUserService _userService;

        private readonly Mapper _mapper = new();

        public ShoppingCartController(IShoppingCartService shoppingCartService, IUserService userService)
        {
            this._shoppingCartService = shoppingCartService;
            this._userService = userService;
        }

        public async Task<IActionResult> Index()
        {
             var cartItems = new List<CartItemViewModel>();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetCurrentUser(User);
                var cartItemDTOs = _shoppingCartService.GetItems(user.Id);
                cartItems = _mapper.Map(cartItemDTOs).ToList();
            }
            else
            {
                var cookies = Request.Cookies["StoreName_CartItems"];
                if (cookies != null)
                {
                    var cartItemDTOs = _shoppingCartService.GetDeserializedCartItems(cookies);
                    cartItems = _mapper.Map(cartItemDTOs).ToList();
                }
            }

            return View(cartItems);
        }

        public async Task<IActionResult> Buy(int itemId)
        {
            var cartItemDTO = new CartItemDTO()
            {
                Item = new ItemBaseDTO() { Id = itemId },
                Amount = 1,
            };

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetCurrentUser(User);
                var userDto = new UserDTO() { Id = user.Id };
                cartItemDTO.User = userDto;
                _shoppingCartService.AddItem(cartItemDTO);
            }
            else
            {
                var cookies = Request.Cookies["StoreName_CartItems"];
                var serializedCartItem = _shoppingCartService.GetSerializedCartItem(cartItemDTO);
                cookies += $"-{serializedCartItem}";
                this.SaveCookies(cookies);
            }
            
            return Redirect("Index");
        }

        public IActionResult ChangeAmountToNew(int cartItemId, int amount)
        {
            if (User.Identity.IsAuthenticated)
            {
                _shoppingCartService.ChangeAmountToNew(cartItemId, amount);
            }
            else
            {
                var cookies = Request.Cookies["StoreName_CartItems"];
                var newCookies = this._shoppingCartService.ChangeAmountToNew(cartItemId, amount, cookies);
                this.SaveCookies(newCookies);
            }

            return Redirect("Index");
        }

        public IActionResult ChangeAmount(int cartItemId, int amount)
        {
            if (User.Identity.IsAuthenticated)
            {
                _shoppingCartService.ChangeAmount(cartItemId, amount);
            }
            else
            {
                var cookies = Request.Cookies["StoreName_CartItems"];
                var newCookies = this._shoppingCartService.ChangeAmount(cartItemId, amount, cookies);
                this.SaveCookies(newCookies);
            }

            return Redirect("Index");
        }

        public IActionResult Delete(int cartItemId)
        {
            if (User.Identity.IsAuthenticated)
            {
                _shoppingCartService.DeleteItem(cartItemId);
            }
            else
            {
                var cookies = Request.Cookies["StoreName_CartItems"];
                var newCookies = _shoppingCartService.DeleteItem(cartItemId, cookies);
                this.SaveCookies(newCookies);
            }

            return Redirect("Index");
        }

        private void SaveCookies(string cookies)
        {
            var cookieOptions = new CookieOptions() { Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("StoreName_CartItems", cookies, cookieOptions);
        }
    }
}