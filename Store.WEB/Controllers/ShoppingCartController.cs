﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.ViewModels;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        private readonly IUserService _userService;

        // temp
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ItemBaseDTO, ItemBase>();
            cfg.CreateMap<CartItemDTO, CartItemViewModel>();
        }).CreateMapper();

        public ShoppingCartController(IShoppingCartService shoppingCartService, IUserService userService)
        {
            _shoppingCartService = shoppingCartService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = new List<CartItemViewModel>();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetCurrentUser(User);
                var cartItemDTOs = _shoppingCartService.GetItems(user);
                cartItems = _mapper.Map<IEnumerable<CartItemViewModel>>(cartItemDTOs).ToList();
            }

            return View(cartItems);
        }

        public async Task<IActionResult> Buy(int itemId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetCurrentUser(User);
                var userDto = new UserDTO() { Email = user.Email, PhoneNumber = user.PhoneNumber };

                var cartItem = new CartItemDTO()
                {
                    Item = new ItemBaseDTO() { Id = itemId },
                    Amount = 1,
                    User = userDto,
                };

                _shoppingCartService.AddItem(cartItem);
            }

            return Redirect("Index");
        }
    }
}
