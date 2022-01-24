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
        public ItemBaseDTO Item { get; set; }

        public int ItemAmount { get; set; }

        public UserDTO User { get; set; }

        public DeliveryOptions Delivery { get; set; }

        public PaymentOptions Payment { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsPaid { get; set; }

        public string? Details { get; set; }
    }
}
