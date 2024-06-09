using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class OrderService(Guid id, List<IProductService> products, string promoCode, float shippingCost, float total, string connectionString)
    : IOrderService
{
    public Guid Id { get; } = id;
    public List<IProductService> Products { get; } = products;
    public string PromoCode { get; } = promoCode;
    public float ShippingCost { get; } = shippingCost;
    public float Total { get; } = total;
    
    private readonly PetStoreDataContext _context = new(connectionString);

    public void AddOrder()
    {
        _context.Orders.InsertOnSubmit(new Order
        {
            Id = Id,
            PromoCode = PromoCode,
            ShippingCost = ShippingCost,
            Total = Total
        });
        _context.SubmitChanges();
    }
    
    public static List<IOrderService> GetOrders(string connectionString)
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
                    (PetType)product.PetType,
                    connectionString
                ));
            }
            orderServices.Add(new OrderService(
                order.Id,
                productServices,
                order.PromoCode,
                order.ShippingCost,
                order.Total,
                connectionString
            ));
        }
        return orderServices;
    }
    public static IOrderService GetOrder(Guid id, string connectionString)
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
                (PetType)product.PetType,
                connectionString
            ));
        }
        return new OrderService(
            order.Id,
            productServices,
            order.PromoCode,
            order.ShippingCost,
            order.Total,
            connectionString
        );
    }
}