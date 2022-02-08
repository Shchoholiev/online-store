using Store.BLL.DTO;
using Store.BLL.DTO.OrdersDTO;
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

        public void AddItems(string cookies, string userId)
        {
            var userDTO = new UserDTO { Id = userId };

            var regex = new Regex("[-]");
            var cookiesArray = regex.Split(cookies)
                                    .Where(s => !string.IsNullOrEmpty(s));
            foreach (var cookie in cookiesArray)
            {
                var cartItemDTO = this.GetDeserializedCartItemForDatabase(cookie);
                cartItemDTO.User = userDTO;
                var cartItem = _mapper.Map(cartItemDTO);

                var dbCartItem = _repository.GetAll(
                    c => c.User.Id == cartItem.User.Id
                    && c.Item.Id == cartItem.Item.Id, 
                    c => c.Item).FirstOrDefault();
                if (dbCartItem == null)
                {
                    _repository.Attach(cartItem.Item);
                    _repository.Add(cartItem);
                }
            }
        }

        public void DeleteItem(int id)
        {
            _repository.Delete(id);
        }

        public string DeleteItem(int id, string cookies)
        {
            var matchRegex = new Regex(string.Format($"(-)?i{id}a[0-9]*"));
            var newCookies = matchRegex.Replace(cookies, string.Empty);

            return newCookies;
        }

        public CartItemDTO GetItem(int id)
        {
            var cartItem = _repository.GetItem(id);
            var cartItemDTO = _mapper.Map(cartItem);

            return cartItemDTO;
        }

        public IEnumerable<CartItemDTO> GetItems(string userId)
        {
            var cartItems = _repository.GetAll(c => c.User.Id == userId && c.Order == null,
                c => c.Item, c => c.Item.Brand, c => c.Item.Model, c => c.Item.Image);

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
            var cookiesArray = regex.Split(cookies)
                                    .Where(s => !string.IsNullOrEmpty(s));
            foreach (var cookie in cookiesArray)
            {
                cartItemDTOs.Add(this.GetDeserializedCartItem(cookie));
            }

            return cartItemDTOs;
        }

        public void ChangeAmountToNew(int id, int amount)
        {
            var cartItem = _repository.GetItem(id, c => c.Item);
            cartItem.Amount = amount;
            _repository.Update(cartItem);
        }

        public string ChangeAmountToNew(int id, int amount, string cookies)
        {
            var matchRegex = new Regex(string.Format($"i{id}a[0-9]*"));
            var newCookies = matchRegex.Replace(cookies, $"i{id}a{amount}");

            return newCookies;
        }

        public void ChangeAmount(int id, int amount)
        {
            var cartItem = _repository.GetItem(id, c => c.Item);            
            cartItem.Amount += amount;
            if (cartItem.Amount == 0)
            {
                this.DeleteItem(id);
                return;
            }
            _repository.Update(cartItem);
        }

        public string ChangeAmount(int id, int amount, string cookies)
        {
            string newCookies;
            var matchRegex = new Regex(string.Format($"i{id}a[0-9]*"));
            var cartItem = matchRegex.Match(cookies).ToString();

            var amountRegex = new Regex(string.Format($"i{id}a"));
            int.TryParse(amountRegex.Replace(cartItem, string.Empty), out int itemAmount);

            itemAmount += amount;
            if (itemAmount == 0)
            {
                newCookies = this.DeleteItem(id, cookies);
            }
            else 
            {
                newCookies = matchRegex.Replace(cookies, $"i{id}a{itemAmount}");
            }

            return newCookies;
        }

        private CartItemDTO GetDeserializedCartItem(string serialized)
        {
            var regex = new Regex("[ia]");
            var array = regex.Split(serialized)
                             .Where(s => !string.IsNullOrWhiteSpace(s))
                             .Select(s => int.Parse(s))
                             .ToArray();
            var item = _itemsRepository.GetItem(array[0]);
            var itemDTO = _mapper.Map(item);
            var deserializedItem = new CartItemDTO { Id = array[0], Item = itemDTO, Amount = array[1] };

            return deserializedItem;
        }

        private CartItemDTO GetDeserializedCartItemForDatabase(string serialized)
        {
            var regex = new Regex("[ia]");
            var array = regex.Split(serialized)
                             .Where(s => !string.IsNullOrWhiteSpace(s))
                             .Select(s => int.Parse(s))
                             .ToArray();
            var deserializedItem = new CartItemDTO { Item = new ItemBaseDTO { Id = array[0] }, Amount = array[1] };

            return deserializedItem;
        }
    }
}
