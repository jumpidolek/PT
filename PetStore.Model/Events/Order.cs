using System;
using System.Collections.Generic;
using PetStore.Model.Inventory;

namespace PetStore.Model.Events;

public class Order
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public string PromoCode { get; set; }
    public float ShippingCost { get; set; }
    public float Total { get; set; }
}