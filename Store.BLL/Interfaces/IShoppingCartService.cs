using Store.BLL.DTO;
using Store.DAL.Entities.Identity;

namespace Store.BLL.Interfaces
{
    public interface IShoppingCartService
    {
        void AddItem(CartItemDTO cartItemDTO);

        IEnumerable<CartItemDTO> GetItems(User user);
    }
}
