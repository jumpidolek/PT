using System;
using System.Collections.Generic;
using PetStore.Service.Implementation;

namespace PetStore.Service.API;

public interface IOrderService
{
    public Guid Id { get; set; }
    public List<IProductService> Products { get; set; }
    public string PromoCode { get; set; }
    public float ShippingCost { get; set; }
    public float Total { get; set; }

    public void AddOrder();
}