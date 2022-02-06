using Store.BLL.DTO;
using Store.DAL.Entities.Identity;

namespace Store.BLL.Interfaces
{
    public interface IShoppingCartService
    {
        void AddItem(CartItemDTO cartItemDTO);

        void DeleteItem(int id);

        string DeleteItem(int id, string cookies);

        CartItemDTO GetItem(int id);

        IEnumerable<CartItemDTO> GetItems(User user);

        string GetSerializedCartItem(CartItemDTO cartItemDTO);

        CartItemDTO GetDeserializedCartItem(string serialized);

        List<CartItemDTO> GetDeserializedCartItems(string cookies);

        void ChangeAmountToNew(int id, int amount);

        string ChangeAmountToNew(int id, int amount, string cookies);

        void ChangeAmount(int id, int amount);

        string ChangeAmount(int id, int amount, string cookies);
    }
}
