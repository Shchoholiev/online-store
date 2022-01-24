﻿using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;

namespace Store.DAL.Entities.Orders;

public class Order : EntityBase
{
    public int ItemId { get; set; }
    public int ItemAmount { get; set; }
    public User User { get; set; }
}