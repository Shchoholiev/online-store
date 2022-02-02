using Store.BLL.DTO;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;
using Store.BLL.Mappers;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Orders;
using Store.DAL.Repository;

namespace Store.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        private readonly IGenericRepository<ItemBase> _itemRepository;

        private readonly Mapper _mapper = new();

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<ItemBase> itemRepo)
        {
            _orderRepository = orderRepo;
            _itemRepository = itemRepo;
        }

        public OperationDetails MakeOrder(OrderDTO orderDTO)
        {
            var operationDetails = new OperationDetails();

            //foreach (var cart in orderDTO.Items)
            //{
            //    if (!CheckAmount(cart.Item.Id, cart.Amount))
            //        operationDetails.AddError(
            //            $"There is no {cart.Item.Amount} {cart.Item.Brand}. " +
            //            $"Only {GetItemAmount(cart.Item.Id)} available.");
            //}

            if (operationDetails.Errors.Count > 0)
                return operationDetails;

            var order = _mapper.Map(orderDTO);
            order.CreationTime = DateTime.Now;

            // add transaction
            foreach (var cart in order.Items)
            {
                var item = cart.Item;
                item.Amount -= cart.Amount;
                _itemRepository.Update(item);
            }

            _orderRepository.Add(order);

            operationDetails.Succeeded = true;
            return operationDetails;
        }

        public IEnumerable<OrderDTO> GetOrders(int userId)
        {
            var orders = _orderRepository.GetAll(o => o.User.Id == userId.ToString());

            var orderDtos = _mapper.Map(orders);

            return orderDtos;
        }

        private bool CheckAmount(int itemId, int amount)
        {
            return GetItemAmount(itemId) - amount >= 0;
        }

        private int GetItemAmount(int itemId)
        {
            var item = _itemRepository.GetItem(itemId);
            return item != null ? item.Amount : 0;
        }
    }

}
