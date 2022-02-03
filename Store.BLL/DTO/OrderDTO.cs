using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Enums;

namespace Store.BLL.DTO
{
    public class OrderDTO
    {
        public List<CartItemDTO> Items { get; set; }

        public UserDTO User { get; set; }

        public DeliveryOptions Delivery { get; set; }

        public string? DeliveryAdress { get; set; }

        public PaymentOptions Payment { get; set; }

        public bool IsPaid { get; set; }

        public string? Details { get; set; }
    }
}
