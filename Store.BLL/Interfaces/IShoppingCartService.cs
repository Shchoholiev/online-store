using Store.BLL.DTO;
using Store.DAL.Entities.Identity;

namespace Store.BLL.Interfaces
{
    public interface IShoppingCartService
    {
        void AddItem(CartItemDTO cartItemDTO);

        IEnumerable<CartItemDTO> GetItems(User user);

        string GetSerializedCartItem(CartItemDTO cartItemDTO);

        CartItemDTO GetDeserializedCartItem(string serialized);

        List<CartItemDTO> GetDeserializedCartItems(string cookies);
    }
}
