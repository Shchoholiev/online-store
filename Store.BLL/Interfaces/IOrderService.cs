using Store.BLL.DTO.OrdersDTO;
using Store.BLL.Infrastructure;

namespace Store.BLL.Interfaces
{
    public interface IOrderService
    {
        OperationDetails MakeOrder(OrderDTO orderDTO);

        IEnumerable<OrderDTO> GetOrders(string userId);
    }
}
