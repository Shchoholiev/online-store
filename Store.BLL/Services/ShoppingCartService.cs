using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.DAL.Entities.Identity;
using Store.DAL.Entities.Orders;
using Store.DAL.Repository;

namespace Store.BLL.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IGenericRepository<CartItem> _repository;

        private readonly Mapper.Mapper _mapper = new();

        public ShoppingCartService(IGenericRepository<CartItem> repository)
        {
            _repository = repository;
        }

        public void AddItem(CartItemDTO cartItemDTO)
        {
            var cartItem = _mapper.Map(cartItemDTO);

            _repository.Attach(cartItem.Item, cartItem.User);

            _repository.Add(cartItem);

            //if (cartItemDTO.User != null)
            //{
            //    var cartItem = _mapper.Map(cartItemDTO);
            //    _repository.Add(cartItem);
            //}

            //AddItemToCookie(cartItemDTO);
        }

        public IEnumerable<CartItemDTO> GetItems(User user)
        {
            var cartItems = _repository.GetWithFiltersAndInclude(c => c.User == user, c => c.Item);

            var cartItemsDTO = _mapper.Map(cartItems);

            return cartItemsDTO;
        }

        //private void AddItemToCookie(CartItemDTO cartItemDTO)
        //{
            
        //}
    }
}
