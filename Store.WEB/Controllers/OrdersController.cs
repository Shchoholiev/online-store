using Microsoft.AspNetCore.Mvc;
using Store.Areas.Identity.ViewModels;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.ViewMappers;
using Store.ViewModels;

namespace Store.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IShoppingCartService _shoppingCartService;

        private readonly IUserService _userService;

        private readonly Mapper _mapper = new();

        public OrdersController(IOrderService orderService, IUserService userService, IShoppingCartService shoppingCartService)
        {
            this._orderService = orderService;
            this._userService = userService;
            this._shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            var userDTO = await this._userService.GetCurrentUser(User);
            var orderDTOs = this._orderService.GetOrders(userDTO.Id);
            var orders = this._mapper.Map(orderDTOs);

            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var orderDTO = this._orderService.GetOrder(id);
            var order = this._mapper.Map(orderDTO);

            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> MakeOrder()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Account", new { area = "Identity", ReturnUrl = "/Orders/MakeOrder" });
            }

            var user = await this._userService.GetCurrentUser(User);
            var cartItemDTOs = this._shoppingCartService.GetItems(user.Id);
            var cartItems = this._mapper.Map(cartItemDTOs).ToList();

            return View(new OrderViewModel(cartItems));
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder([Bind("Delivery,DeliveryAddress,Payment,Details,TotalPrice")] OrderViewModel order)
        {
            var user = await this._userService.GetCurrentUser(User);
            var cartItemDTOs = this._shoppingCartService.GetItems(user.Id);
            var orderDTO = this._mapper.Map(order);
            orderDTO.Items = cartItemDTOs;
            orderDTO.User = new UserDTO { Id = user.Id };

            var result = this._orderService.MakeOrder(orderDTO);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Messages)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            var cartItemViewModels = this._mapper.Map(cartItemDTOs);
            order.Items = cartItemViewModels;

            return View(order);
        }
    }
}