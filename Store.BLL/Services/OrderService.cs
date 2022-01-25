using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Orders;
using Store.DAL.Repository;

namespace Store.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        private readonly IGenericRepository<ItemBase> _itemRepository;

        private readonly Mapper.Mapper _mapper = new();

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<ItemBase> itemRepo)
        {
            _orderRepository = orderRepo;
            _itemRepository = itemRepo;
        }

        public void MakeOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map(orderDTO);

            order.CreationTime = DateTime.Now;

            _orderRepository.Add(order);
        }

        private bool CheckAmount(int itemId, int amount)
        {
            var item = _itemRepository.GetItem(itemId);

            if (item == null) // ???
                return false;

            return item.Amount - amount >= 0;
        }
    }

}
