using Store.BLL.DTO.OrdersDTO;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;
using Store.BLL.Mappers;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Orders;
using Store.DAL.Repository;
using System.Linq;
using System.Linq.Expressions;

namespace Store.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        private readonly IGenericRepository<CartItem> _cartItemRepository;

        private readonly IGenericRepository<ItemBase> _itemRepository;

        private readonly Mapper _mapper = new();

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<ItemBase> itemRepo, 
            IGenericRepository<CartItem> cartRepo)
        {
            _orderRepository = orderRepo;
            _itemRepository = itemRepo;
            _cartItemRepository = cartRepo;
        }

        public OperationDetails MakeOrder(OrderDTO orderDTO)
        {
            var operationDetails = new OperationDetails();

            foreach (var cart in orderDTO.Items)
            {
                if (!CheckAmount(cart.Item.Id, cart.Amount))
                {
                    operationDetails.AddMessage($"There is no {cart.Amount} {cart.Item.Brand} {cart.Item.Model}.");
                }
            }

            if (operationDetails.Messages.Count > 0)
            {
                return operationDetails;
            }

            var order = _mapper.Map(orderDTO);
            order.CreationTime = DateTime.Now;

            // add transaction
            foreach (var cart in order.Items)
            {
                var item = cart.Item;
                item.Amount -= cart.Amount;
                _itemRepository.Update(item);
                _orderRepository.Attach(cart, item);
            }

            _orderRepository.Attach(order.Delivery, order.Payment, order.User);
            _orderRepository.Add(order);

            operationDetails.Succeeded = true;
            return operationDetails;
        }

        public OrderDTO GetOrder(int id)
        {
            var order = this._orderRepository.GetItem(id, o => o.Items);
            var orderDTO = this._mapper.Map(order);

            var cartItemDTOs = new List<CartItemDTO>();
            foreach (var cartItem in order.Items)
            {
                var cartItemDb = this._cartItemRepository.GetItem(cartItem.Id, c => c.Item, 
                    c => c.Item.Image, c => c.Item.Brand, c => c.Item.Model, c => c.Item.Color );
                var cartItemDTO = _mapper.Map(cartItemDb);
                cartItemDTOs.Add(cartItemDTO);
            }
            orderDTO.Items = cartItemDTOs;

            return orderDTO;
        }

        public IEnumerable<OrderDTO> GetOrders(string userId)
        {
            var orders = _orderRepository.GetAll(o => o.User.Id == userId);
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
