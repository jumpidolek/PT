using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Model.Models.Inventory;
using PetStore.Model.Models.Users;
using PetStore.Service.API;
using PetStore.Service.Implementation;
using Category = PetStore.Service.API.Category;
using PetType = PetStore.Service.API.PetType;

namespace PetStore.Model.Models.Events;

public class Shipment
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public Supplier Supplier { get; set; }
    
    public static void Add(Shipment c)
    {
        var productServices = new List<IProductService>();
        foreach (var product in c.Products)
        {
            productServices.Add(new ProductService(product.Id, product.Name, product.Description, product.Brand, (Category)product.Category, product.Price, (PetType)product.PetType));
        }
        Task.Run(() => new ShipmentService(c.Id, productServices, new SupplierService(c.Supplier.Id, c.Supplier.Email, c.Supplier.Phone, c.Supplier.Address, c.Supplier.Name)).AddShipment());
    }
    public static Shipment Get(Guid id)
    {
        return Task.Run(() =>
        {
            var shipmentService = ShipmentService.GetShipment(id);
            var products = new List<Product>();
            foreach (var productService in shipmentService.Products)
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
            return new Shipment
            {
                Id = shipmentService.Id,
                Products = products,
                Supplier = new Supplier
                {
                    Id = shipmentService.Supplier.Id,
                    Email = shipmentService.Supplier.Email,
                    Phone = shipmentService.Supplier.Phone,
                    Address = shipmentService.Supplier.Address,
                    Name = shipmentService.Supplier.Name
                }
            };
        }).Result;
    }
    public static List<Shipment> GetAll()
    {
        return Task.Run(() =>
        {
            var shipmentServices = ShipmentService.GetShipments();
            var shipments = new List<Shipment>();
            foreach (var shipmentService in shipmentServices)
            {
                var products = new List<Product>();
                foreach (var productService in shipmentService.Products)
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
                shipments.Add(new Shipment
                {
                    Id = shipmentService.Id,
                    Products = products,
                    Supplier = new Supplier
                    {
                        Id = shipmentService.Supplier.Id,
                        Email = shipmentService.Supplier.Email,
                        Phone = shipmentService.Supplier.Phone,
                        Address = shipmentService.Supplier.Address,
                        Name = shipmentService.Supplier.Name
                    }
                });
            }
            return shipments;
        }).Result;
    }
}