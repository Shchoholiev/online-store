using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities.Orders
{
    public class CartItem : EntityBase
    {
        public ItemBase Item { get; set; }

        public int Amount { get; set; }

        public User User { get; set; }

        public Order? Order { get; set; }
    }
}
