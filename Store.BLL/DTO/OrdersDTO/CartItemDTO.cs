namespace Store.BLL.DTO.OrdersDTO
{
    public class CartItemDTO : EntityBaseDTO
    {
        public ItemBaseDTO Item { get; set; }

        public int Amount { get; set; }

        public UserDTO? User { get; set; }
    }
}
