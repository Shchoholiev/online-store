using Store.BLL.DTO.OrdersDTO;
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

        private readonly IGenericRepository<DeliveryOption> _deliveryOptionsRepository;

        private readonly IGenericRepository<PaymentOption> _paymentOptionsRepository;

        private readonly Mapper _mapper = new();

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<ItemBase> itemRepo,
                            IGenericRepository<DeliveryOption> deliveryRepo, IGenericRepository<PaymentOption> paymentRepo)
        {
            _orderRepository = orderRepo;
            _itemRepository = itemRepo;
            _deliveryOptionsRepository = deliveryRepo;
            _paymentOptionsRepository = paymentRepo;
        }

        public OperationDetails MakeOrder(OrderDTO orderDTO)
        {
            var operationDetails = new OperationDetails();

            foreach (var cart in orderDTO.Items)
            {
                if (!CheckAmount(cart.Item.Id, cart.Amount))
                    operationDetails.AddMessage(
                        $"There is no {cart.Amount} {cart.Item.Brand} {cart.Item.Model}. " + //change to method in ItemBase
                        $"Only {GetItemAmount(cart.Item.Id)} available.");
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

        public IEnumerable<DeliveryOptionDTO> GetDeliveryOptions()
        {
            var deliveryOptions = this._deliveryOptionsRepository.GetAll();
            return this._mapper.Map(deliveryOptions);
        }

        public IEnumerable<PaymentOptionDTO> GetPaymentOptions()
        {
            var paymentOptions = this._paymentOptionsRepository.GetAll();
            return this._mapper.Map(paymentOptions);
        }

        public IEnumerable<OrderDTO> GetOrders(string userId)
        {
            var orders = _orderRepository.GetAll(o => o.User.Id == userId, o => o.Items);
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
