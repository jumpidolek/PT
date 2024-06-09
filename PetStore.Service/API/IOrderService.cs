using System;
using System.Collections.Generic;
using PetStore.Service.Implementation;

namespace PetStore.Service.API;

public interface IOrderService
{
    public Guid Id { get; }
    public List<IProductService> Products { get; }
    public string PromoCode { get; }
    public float ShippingCost { get; }
    public float Total { get; }

    public void AddOrder();
}