using Store.BLL.DTO.OrdersDTO;
using Store.BLL.Infrastructure;

namespace Store.BLL.Interfaces
{
    public interface IOrderService
    {
        OperationDetails MakeOrder(OrderDTO orderDTO);

        OrderDTO GetOrder(int id);

        IEnumerable<OrderDTO> GetOrders();

        IEnumerable<OrderDTO> GetOrders(string userId);

        int GetCount();
    }
}
