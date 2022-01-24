﻿using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;
using Store.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DAL.Entities.Orders;

public class Order : EntityBase
{
    public ItemBase Item { get; set; }

    

    public int ItemAmount { get; set; }

    public User User { get; set; }

    public DeliveryOptions Delivery { get; set; }

    public PaymentOptions Payment { get; set; }

    public DateTime CreationTime { get; set; }

    public bool IsPaid { get; set; }

    public string? Details { get; set; }
}