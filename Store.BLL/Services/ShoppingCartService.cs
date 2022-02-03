using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.BLL.Mappers;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;
using Store.DAL.Entities.Orders;
using Store.DAL.Repository;
using System.Text.RegularExpressions;

namespace Store.BLL.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IGenericRepository<CartItem> _repository;

        private readonly IGenericRepository<ItemBase> _itemsRepository;

        private readonly Mapper _mapper = new();

        public ShoppingCartService(IGenericRepository<CartItem> repository, IGenericRepository<ItemBase> itemsRepository)
        {
            this._repository = repository;
            this._itemsRepository = itemsRepository;
        }

        public void AddItem(CartItemDTO cartItemDTO)
        {
            var cartItem = _mapper.Map(cartItemDTO);

            _repository.Attach(cartItem.Item, cartItem.User);
            _repository.Add(cartItem);
        }

        public IEnumerable<CartItemDTO> GetItems(User user)
        {
            var cartItems = _repository.GetAll();

            var cartItemsDTO = _mapper.Map(cartItems);

            return cartItemsDTO;
        }

        public string GetSerializedCartItem(CartItemDTO cartItem)
        {
            var serializedItem = $"i{cartItem.Item.Id}a{cartItem.Amount}";
            return serializedItem;
        }

        public List<CartItemDTO> GetDeserializedCartItems(string cookies)
        {
            var cartItemDTOs = new List<CartItemDTO>();
            var regex = new Regex("[-]");
            var cookiesArray = regex.Split(cookies);
            foreach (var cookie in cookiesArray)
            {
                cartItemDTOs.Add(this.GetDeserializedCartItem(cookie));
            }

            return cartItemDTOs;
        }

        public CartItemDTO GetDeserializedCartItem(string serialized)
        {
            var regex = new Regex("[ia]");
            var array = regex.Split(serialized)
                             .Where(s => !string.IsNullOrWhiteSpace(s))
                             .Select(s => int.Parse(s))
                             .ToArray();
            var item = _itemsRepository.GetItem(array[0]);
            var itemDTO = _mapper.Map(item);
            var deserializedItem = new CartItemDTO() { Item = itemDTO, Amount = array[1] };

            return deserializedItem;
        }
    }
}
