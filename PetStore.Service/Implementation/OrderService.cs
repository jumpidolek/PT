using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class OrderService(Guid id, List<IProductService> products, string promoCode, float shippingCost, float total)
    : IOrderService
{
    public Guid Id { get; set; } = id;
    public List<IProductService> Products { get; set; } = products;
    public string PromoCode { get; set; } = promoCode;
    public float ShippingCost { get; set; } = shippingCost;
    public float Total { get; set; } = total;
    
    private readonly PetStoreDataContext _context = new();

    public void AddOrder()
    {
        _context.Orders.InsertOnSubmit(new Order
        {
            Id = id,
            PromoCode = promoCode,
            ShippingCost = shippingCost,
            Total = total
        });
        _context.SubmitChanges();
    }
    
    public static List<IOrderService> GetOrders()
    {
        var context = new PetStoreDataContext();
        var orders = context.Orders.ToList();
        var orderServices = new List<IOrderService>();
        foreach (var order in orders)
        {
            var productServices = new List<IProductService>();
            foreach (var product in order.Products)
            {
                productServices.Add(new ProductService(
                    product.Id,
                    product.Name,
                    product.Description,
                    product.Brand,
                    (Category)product.Category,
                    product.Price,
                    (PetType)product.PetType
                ));
            }
            orderServices.Add(new OrderService(
                order.Id,
                productServices,
                order.PromoCode,
                order.ShippingCost,
                order.Total
            ));
        }
        return orderServices;
    }
    public static IOrderService GetOrder(Guid id)
    {
        var context = new PetStoreDataContext();
        var order = context.Orders.First(o => o.Id == id);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        var productServices = new List<IProductService>();
        foreach (var product in order.Products)
        {
            productServices.Add(new ProductService(
                product.Id,
                product.Name,
                product.Description,
                product.Brand,
                (Category)product.Category,
                product.Price,
                (PetType)product.PetType
            ));
        }
        return new OrderService(
            order.Id,
            productServices,
            order.PromoCode,
            order.ShippingCost,
            order.Total
        );
    }
}