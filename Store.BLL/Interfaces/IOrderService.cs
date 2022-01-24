using Store.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Interfaces
{
    public interface IOrderService
    {
        public void MakeOrder(ItemBaseDTO item, UserDTO user, int amount);
    }
}
