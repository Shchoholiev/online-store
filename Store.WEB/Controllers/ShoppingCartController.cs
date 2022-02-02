using Microsoft.AspNetCore.Mvc;
using Store.BLL.DTO;
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
                var cartItemDTOs = _shoppingCartService.GetItems(user);
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
                var userDto = new UserDTO() { Email = user.Email, PhoneNumber = user.PhoneNumber };
                cartItemDTO.User = userDto;
                _shoppingCartService.AddItem(cartItemDTO);
            }
            else
            {
                var cookies = Request.Cookies["StoreName_CartItems"];
                var serializedCartItem = _shoppingCartService.GetSerializedCartItem(cartItemDTO);

                if (cookies != null)
                {
                    cookies += $"-{serializedCartItem}";
                }
                else
                {
                    cookies = serializedCartItem;
                }

                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(7);
                HttpContext.Response.Cookies.Append("StoreName_CartItems", cookies, cookieOptions);
            }
            
            return Redirect("Index");
        }
    }
}
