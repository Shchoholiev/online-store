using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.Orders;
using Store.DAL.Repository;

namespace Store.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _repository;

        private readonly IGenericRepository<ItemBase> _itemRepository;

        private readonly Mapper.Mapper _mapper = new();

        public void MakeOrder(ItemBaseDTO item, UserDTO user, int amount)
        {
            var order = new Order();

            _repository.Add(order);
        }
    }

    enum ItemTypes
    {
        Phone,
        Laptop
    }
}
