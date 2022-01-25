using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class CartItemDTO
    {
        public ItemBaseDTO Item { get; set; }

        public int Amount { get; set; }

        public UserDTO User { get; set; }
    }
}
