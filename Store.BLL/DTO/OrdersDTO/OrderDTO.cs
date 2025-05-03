namespace Store.BLL.DTO.OrdersDTO
{
    public class OrderDTO : EntityBaseDTO
    {
        public IEnumerable<CartItemDTO> Items { get; set; }

        public UserDTO User { get; set; }

        public int TotalPrice { get; set; }

        public int Delivery { get; set; }

        public string? DeliveryAddress { get; set; }

        public DateTime CreationTime { get; set; }

        public int Payment { get; set; }

        public bool IsPaid { get; set; }

        public string? Details { get; set; }
    }
}
