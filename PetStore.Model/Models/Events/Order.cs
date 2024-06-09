using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Model.Models.Inventory;
using PetStore.Service.API;
using PetStore.Service.Implementation;
using Category = PetStore.Service.API.Category;
using PetType = PetStore.Service.API.PetType;

namespace PetStore.Model.Models.Events;

public class Order
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public string PromoCode { get; set; }
    public float ShippingCost { get; set; }
    public float Total { get; set; }
    
    public static void Add(Order c)
    {
        var productServices = new List<IProductService>();
        foreach (var product in c.Products)
        {
            productServices.Add(new ProductService(product.Id, product.Name, product.Description, product.Brand, (Category)product.Category, product.Price, (PetType)product.PetType));
        }
        Task.Run(() => new OrderService(c.Id, productServices, c.PromoCode, c.ShippingCost, c.Total).AddOrder());
    }
    public static Order Get(Guid id)
    {
        return Task.Run(() =>
        {
            var orderService = OrderService.GetOrder(id);
            var products = new List<Product>();
            foreach (var productService in orderService.Products)
            {
                products.Add(new Product
                {
                    Id = productService.Id,
                    Name = productService.Name,
                    Description = productService.Description,
                    Brand = productService.Brand,
                    Category = (Inventory.Category)productService.Category,
                    Price = productService.Price,
                    PetType = (Inventory.PetType)productService.PetType
                });
            }
            return new Order
            {
                Id = orderService.Id,
                Products = products,
                PromoCode = orderService.PromoCode,
                ShippingCost = orderService.ShippingCost,
                Total = orderService.Total
            };
        }).Result;
    }
    public static List<Order> GetAll()
    {
        return Task.Run(() =>
        {
            var orderServices = OrderService.GetOrders();
            var orders = new List<Order>();
            foreach (var orderService in orderServices)
            {
                var products = new List<Product>();
                foreach (var productService in orderService.Products)
                {
                    products.Add(new Product
                    {
                        Id = productService.Id,
                        Name = productService.Name,
                        Description = productService.Description,
                        Brand = productService.Brand,
                        Category = (Inventory.Category)productService.Category,
                        Price = productService.Price,
                        PetType = (Inventory.PetType)productService.PetType
                    });
                }
                orders.Add(new Order
                {
                    Id = orderService.Id,
                    Products = products,
                    PromoCode = orderService.PromoCode,
                    ShippingCost = orderService.ShippingCost,
                    Total = orderService.Total
                });
            }
            return orders;
        }).Result; 
    }
}